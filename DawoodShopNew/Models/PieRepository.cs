using Microsoft.EntityFrameworkCore;

namespace DawoodShopNew.Models
{
    public class PieRepository:IPieRepository
    {
        private readonly DawoodShopNewDbContext _dawoodShopNewDbContext;

        public PieRepository(DawoodShopNewDbContext dawoodShopNewDbContext)
        {
            _dawoodShopNewDbContext = dawoodShopNewDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return _dawoodShopNewDbContext.Pies.Include(i => i.Category); }
        }

        public IEnumerable<Pie> PiesOfTheWeek { get { return _dawoodShopNewDbContext.Pies.Where(o => o.IsPieOfTheWeek); } }

        public Pie?GetPieById(int id) { return _dawoodShopNewDbContext.Pies.FirstOrDefault(i => i.PieId==id); }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _dawoodShopNewDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
