using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace Maui.CommandPattern.BlazorHybrid.Components.Pages
{
    public partial class MtgCardSummary : SummaryPageBase<MtgCard>
    {
        private string DetailRoute = "mtgcard";
        protected override async Task OnInitializedAsync()
        {
            base.GetData();
        }

        public override Func<MtgCard, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Name!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Description!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Color!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Type!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.MtgSet!.Name!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.IsActive}".Contains(_searchString))
                return true;

            return false;
        };
    }
}
