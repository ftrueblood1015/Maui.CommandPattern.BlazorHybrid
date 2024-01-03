using Maui.CommandPattern.BlazorHybrid.Services;
using Maui.CommandPattern.EntityLibrary.Models;

namespace Maui.CommandPattern.BlazorHybrid.Commands
{
    public class AddEntityCommand<T> : CommandBase, IAddEntityCommand
        where T: ModelBase
    {
        private readonly IServiceBase<T>? Service;
        private T Entity;

        public AddEntityCommand(IServiceBase<T>? service, T entity)
        {
            Service = service;
            Entity = entity;
        }

        public override void Execute()
        {
            if (Service == null)
            {
                throw new Exception($"{nameof(Service)}  is null!");
            }

            Service.Add(Entity);
        }
    }
}
