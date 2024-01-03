namespace Maui.CommandPattern.BlazorHybrid.Commands
{
    public interface ICommandBase
    {
        void Execute();

        void Execute(string s);
    }
}
