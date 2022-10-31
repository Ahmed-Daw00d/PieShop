using DawoodShopNew.Models;

namespace DawoodShopNew.ViewModels
{
    public class PieListViewModel
    {
        public string? TitleHead { get; }
        public IEnumerable<Pie> Pies { get;  }

        public PieListViewModel(IEnumerable<Pie> pies,string? titleHead)
        {
            TitleHead = titleHead;
            Pies = pies;
        }
    }
}
