using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        // get
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(string id)
        {
            try
            {
                var idHangHoa = hangHoas.SingleOrDefault(hh => hh.Id.Equals(Guid.Parse(id)));
                if (idHangHoa == null)
                {
                    return NotFound();
                }
                return Ok();
            } catch
            {
               return BadRequest();
            }
        }

        //Post
        [HttpPost]
        public IActionResult Create(HangHoa hangHoa)
        {
            var hangHoaNew = new HangHoa
            {
                Id = Guid.NewGuid(),
                TenHangHoa = hangHoa.TenHangHoa,
                Gia = hangHoa.Gia,
            };
            hangHoas.Add(hangHoaNew);
            return Ok(new
            {
                Success = true, Data = hangHoaNew
            });
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hanghoa)
        {
            try
            {
                var idHangHoa = hangHoas.SingleOrDefault(hh => hh.Id.Equals(Guid.Parse(id)));
                if (idHangHoa == null)
                {
                    return NotFound();
                }
                if(id != idHangHoa.Id.ToString() ) { return BadRequest(); }
                idHangHoa.TenHangHoa = hanghoa.TenHangHoa;
                idHangHoa.Gia = hanghoa.Gia;
                return Ok(idHangHoa);
            }
            catch
            {
                return BadRequest();

            }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var idHangHoa = hangHoas.SingleOrDefault(hh => hh.Id.Equals(Guid.Parse(id)));
                if (idHangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(idHangHoa);
                return Ok();
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}
