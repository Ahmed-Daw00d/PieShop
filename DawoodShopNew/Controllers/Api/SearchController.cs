using DawoodShopNew.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DawoodShopNew.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _ipieRepository;

        public SearchController(IPieRepository ipieRepository)
        {
            _ipieRepository = ipieRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll() {

            var allPies = _ipieRepository.AllPies;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            if (!_ipieRepository.AllPies.Any(p => p.PieId == id))
                return NotFound();
            return Ok(_ipieRepository.AllPies.Where(p => p.PieId == id));
           // return Ok(_ipieRepository.GetPieById(id));
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchquary)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            if (!string.IsNullOrEmpty(searchquary))
            {
                pies = _ipieRepository.SearchPies(searchquary);
            }
         
            return new JsonResult(pies);

        }

    }
}
