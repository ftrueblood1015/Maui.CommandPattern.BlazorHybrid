using Maui.CommandPattern.BlazorHybrid.Services;
using Maui.CommandPattern.EntityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.CommandPattern.BlazorHybrid.Commands
{
    public class UpdateEntityCommand<T> : CommandBase, IUpdateEntityCommand
        where T : ModelBase
    {
        private readonly IServiceBase<T>? Service;
        private T Entity;

        public UpdateEntityCommand(IServiceBase<T>? service, T entity)
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

            Service.Update(Entity);
        }
    }
}
