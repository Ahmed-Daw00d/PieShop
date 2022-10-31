using DawoodShopNew.Controllers;
using DawoodShopNew.ViewModels;
using DawoodShopNewTest.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DawoodShopNewTest.Controllers
{
    
    public class PieControllerTest
    {
        [Fact]
        public static void List_EmptyCategory_returnsAllPies() { 
        
            //arrange
            var MockPieRepository= RepositoryMocks.GetPieRepository();
            var MockCategoriyRepository = RepositoryMocks.GetCategoryRepository();
            var PieController = new PieController(MockPieRepository.Object,MockCategoriyRepository.Object);

            //act
            var result = PieController.List("");

            //assert
            var ViewResult= Assert.IsType<ViewResult>(result);
            var PieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(ViewResult.ViewData.Model);
            Assert.Equal(10, PieListViewModel.Pies.Count());


        }
    }
}
