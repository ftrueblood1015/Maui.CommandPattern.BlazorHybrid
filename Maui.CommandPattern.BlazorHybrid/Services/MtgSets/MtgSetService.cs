using Maui.CommandPattern.BlazorHybrid.Repositories.MtgSets;
using Maui.CommandPattern.EntityLibrary.Models;

namespace Maui.CommandPattern.BlazorHybrid.Services.MtgSets
{
    public class MtgSetService : ServiceBase<MtgSet, IMtgSetRepository>, IMtgSetService
    {
        public MtgSetService(IMtgSetRepository repo) : base(repo)
        {
        }
    }
}
