using Maui.CommandPattern.BlazorHybrid.Commands;
using Maui.CommandPattern.BlazorHybrid.Services;
using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Maui.CommandPattern.BlazorHybrid.Components.Pages
{
    public class DetailPageBase<T> : ComponentBase
        where T : ModelBase, new()
    {
        [Inject]
        IServiceBase<T>? Service { get; set; }

        [Inject]
        private ISnackbar? SnackbarService { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        public bool success;

        public MudForm? Form;

        public async void Save(T Entity, string route)
        {
            success = false;
            await Form!.Validate();

            var navCommand = new NavigationCommand(NavigationManager!);

            if (!Form!.IsValid)
            {
                ShowSnackbarMessage($"Form Is Invalid, see errors", MudBlazor.Color.Error);
                return;
            }

            if (Service == null)
            {
                throw new ArgumentNullException(nameof(Service));
            }

            if (Entity.Id == 0)
            {
                Create(Entity);
            }
            else
            {
                Update(Entity);
            }

            navCommand.Execute($"/{route}");
        }

        private void Create(T Entity)
        {
            try
            {
                var AddCommand = new AddEntityCommand<T>(Service, Entity);
                AddCommand.Execute();
                success = true;
                StateHasChanged();
                ShowSnackbarMessage($"Added New {Entity.Name}", MudBlazor.Color.Success);
            }
            catch
            {
                success = false;
                ShowSnackbarMessage($"Could Not Add {Entity.Name}", MudBlazor.Color.Error);
            }
        }

        private void Update(T Entity)
        {
            try
            {
                var UpdateCommand = new UpdateEntityCommand<T>(Service, Entity);
                UpdateCommand.Execute();
                success = true;
                StateHasChanged();
                ShowSnackbarMessage($"Updated New {Entity.Name}", MudBlazor.Color.Success);
            }
            catch
            {
                success = false;
                ShowSnackbarMessage($"Could Not Update {Entity.Name}", MudBlazor.Color.Error);
            }
        }

        public void Cancel(string route)
        {
            var navCommand = new NavigationCommand(NavigationManager!);
            navCommand.Execute($"/{route}");
        }

        public T GetEntity(int Id)
        {
            if (Service == null)
            {
                throw new ArgumentNullException(nameof(Service));
            }

            return Service.GetById(Id) ?? new T() { };
        }

        public void ShowSnackbarMessage(string Message, MudBlazor.Color Color)
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
