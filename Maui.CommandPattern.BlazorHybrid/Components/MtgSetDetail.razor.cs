using Maui.CommandPattern.BlazorHybrid.Components.Pages;
using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace Maui.CommandPattern.BlazorHybrid.Components
{
    public partial class MtgSetDetail : DetailPageBase<MtgSet>
    {
        [Parameter]
        public int EntityId { get; set; }

        public MtgSet? Entity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SetEntity();
            StateHasChanged();
        }

        public void SetEntity()
        {
            if (EntityId == 0)
            {
                Entity = new MtgSet();
            }
            else
            {
                Entity = base.GetEntity(EntityId);
            }
        }
    }
}
