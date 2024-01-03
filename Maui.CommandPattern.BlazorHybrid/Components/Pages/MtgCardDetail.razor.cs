using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace Maui.CommandPattern.BlazorHybrid.Components.Pages
{
    public partial class MtgCardDetail : DetailPageBase<MtgCard>
    {
        [Parameter]
        public int EntityId { get; set; }

        public MtgCard? Entity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SetEntity();
            StateHasChanged();
        }

        public void SetEntity()
        {
            if (EntityId == 0)
            {
                Entity = new MtgCard();
            }
            else
            {
                Entity = base.GetEntity(EntityId);
            }
        }

        public async Task SetChange(int? Id)
        {
            Entity!.MtgSetId = Id;
        }
    }
}
