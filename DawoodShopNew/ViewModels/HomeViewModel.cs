using DawoodShopNew.Models;

namespace DawoodShopNew.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PieOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pie> pieOfTheWeek)
        {
            PieOfTheWeek = pieOfTheWeek;
        }
    }
}
