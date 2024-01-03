using Maui.CommandPattern.BlazorHybrid.Repositories.MtgCards;
using Maui.CommandPattern.EntityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.CommandPattern.BlazorHybrid.Services.MtgCards
{
    public class MtgCardService : ServiceBase<MtgCard, IMtgCardRepository>, IMtgCardService
    {
        public MtgCardService(IMtgCardRepository repo) : base(repo)
        {
        }
    }
}
