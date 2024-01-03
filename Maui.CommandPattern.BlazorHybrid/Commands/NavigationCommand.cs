using Microsoft.AspNetCore.Components;

namespace Maui.CommandPattern.BlazorHybrid.Commands
{
    public class NavigationCommand : CommandBase, INavigationCommand
    {
        private readonly  NavigationManager? NavigationManager;

        public NavigationCommand(NavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
        }

        public override void Execute(string route)
        {
            if (NavigationManager == null)
            {
                throw new Exception($"{nameof(NavigationManager)}  is null!");
            }

            NavigationManager.NavigateTo($"{route}");
        }
    }
}
