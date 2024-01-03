using Maui.CommandPattern.BlazorHybrid.Commands;
using Maui.CommandPattern.BlazorHybrid.Services;
using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Maui.CommandPattern.BlazorHybrid.Components.Pages
{
    public class SummaryPageBase<T> : ComponentBase
        where T : ModelBase
    {
        [Inject]
        IServiceBase<T>? Service { get; set; }

        [Inject]
        private IDialogService? DialogService { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        public List<T>? Entities { get; set; }

        public string? _searchString;

        private string State = "Message box hasn't been opened yet";

        public void GetData()
        {
            if (Service == null)
            {
                throw new Exception($"{nameof(Service)}  is null!");
            }
            var Response = Service.GetAll();
            Entities = Response != null ? Response.ToList() : new List<T>();
            StateHasChanged();
        }

        public virtual Func<T, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Name!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Description!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.IsActive}".Contains(_searchString))
                return true;

            return false;
        };

        public async void OnDeleteClicked(T item)
        {
            if (DialogService == null)
            {
                throw new Exception($"{nameof(DialogService)}  is null!");
            }

            bool? result = await DialogService.ShowMessageBox(
                "Warning",
                "Deleting can not be undone!",
                yesText:"Delete!", cancelText:"Cancel"
            );

            State = result == null ? "Canceled" : "Deleted!";

            if (State != "Canceled")
            {
                Delete(item);
                GetData();
            }
        }

        private bool Delete(T Item)
        {
            if (Service == null)
            {
                throw new Exception($"{nameof(Service)} is null!");
            }

            try
            {
                var result = Service.Delete(Item);

                if (result)
                {
                    ShowSnackbarMessage($"Deleted {Item.Name}", MudBlazor.Color.Success);
                }
                else
                {
                    ShowSnackbarMessage($"Could Not Delete {Item.Name}", MudBlazor.Color.Error);
                }

                return result;
            }
            catch (Exception ex)
            {
                ShowSnackbarMessage($"Could Not Delete {Item.Name}: {ex}", MudBlazor.Color.Error);
                return false;
            }
        }

        public void Edit(T item, string route)
        {
            var navCommand = new NavigationCommand(NavigationManager!);
            navCommand.Execute($"/{route}/{item.Id}");
        }

        public void Add(string route)
        {
            var navCommand = new NavigationCommand(NavigationManager!);
            navCommand.Execute($"/{route}");
        }

        private void ShowSnackbarMessage(string Message, MudBlazor.Color Color)
        {
            if (SnackbarService == null)
            {
                throw new ArgumentNullException(nameof(SnackbarService));
            }

            SnackbarService.Add<MudChip>(new Dictionary<string, object>() {
                { "Text", $"{Message}" },
                { "Color", Color }
            });
        }
    }
}
