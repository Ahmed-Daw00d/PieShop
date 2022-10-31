using DawoodShopNew.Controllers;
using DawoodShopNew.ViewModels;
using DawoodShopNewTest.Mocks;
using System.Linq;
using Xunit;

namespace DawoodShopNewTest.Controllers
{
    public class HomeControllerTests
    {

        [Fact]
        public void Index_Use_PieOfTheWeeks_FromRepository()
        {
            var mockPieRepository = RepositoryMocks.GetPieRepository();

            var homeController =new HomeController(mockPieRepository.Object);

            var result = homeController.Index().ViewData.Model as HomeViewModel;

            Assert.NotNull(result);

            var piesOfTheWeek = result?.PieOfTheWeek?.ToList();
            Assert.NotNull(piesOfTheWeek);
            Assert.True(piesOfTheWeek?.Count() == 3);
            Assert.Equal("Apple Pie", piesOfTheWeek?[0].Name);


        }
    }
}
