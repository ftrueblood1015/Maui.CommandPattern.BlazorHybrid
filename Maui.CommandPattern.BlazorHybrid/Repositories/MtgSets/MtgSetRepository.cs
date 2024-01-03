using Maui.CommandPattern.EntityLibrary;
using Maui.CommandPattern.EntityLibrary.Models;

namespace Maui.CommandPattern.BlazorHybrid.Repositories.MtgSets
{
    public class MtgSetRepository : RepositoryBase<MtgSet, CommandPatternContext>, IMtgSetRepository
    {
        public MtgSetRepository(CommandPatternContext context) : base(context)
        {
        }
    }
}
