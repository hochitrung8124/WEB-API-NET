using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Services;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoasController : ControllerBase
    {
        private IHangHoa _hangHoa;

        public HangHoasController(IHangHoa hangHoa)
        {
            _hangHoa = hangHoa;
        }
        [HttpGet]
        public IActionResult GetProducts(string search) 
        {
            try
            {
                var result = _hangHoa.GetAll(search);
                return Ok(result);
            } 
            catch
            {
                return BadRequest();   
            }
        }
    }
}
