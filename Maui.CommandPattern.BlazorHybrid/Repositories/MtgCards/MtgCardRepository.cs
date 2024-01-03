using Maui.CommandPattern.EntityLibrary;
using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Maui.CommandPattern.BlazorHybrid.Repositories.MtgCards
{
    public class MtgCardRepository : RepositoryBase<MtgCard, CommandPatternContext>, IMtgCardRepository
    {
        public MtgCardRepository(CommandPatternContext context) : base(context)
        {
        }

        public override IEnumerable<MtgCard> GetAll()
        {
            return Context.Set<MtgCard>().Include(set => set.MtgSet);
        }
    }
}
