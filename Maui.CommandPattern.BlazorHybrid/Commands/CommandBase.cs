namespace Maui.CommandPattern.BlazorHybrid.Commands
{
    public abstract class CommandBase : ICommandBase
    {
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual void Execute(string s)
        {
            throw new NotImplementedException();
        }
    }
}
