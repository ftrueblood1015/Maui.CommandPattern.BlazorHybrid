using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace Maui.CommandPattern.BlazorHybrid.Components.Pages
{
    public partial class MtgSetSummary : SummaryPageBase<MtgSet>
    {
        private string DetailRoute = "mtgset";

        protected override async Task OnInitializedAsync()
        {
            base.GetData();
        }

        public override Func<MtgSet, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Name!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Description!.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.IsActive}".Contains(_searchString))
                return true;

            if ($"{x.ReleaseYear}".Contains(_searchString))
                return true;

            return false;
        };
    }
}
