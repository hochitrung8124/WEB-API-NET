using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.data;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaiController(MyDBContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var dsLoai = _context.Loais.SingleOrDefault(loai => loai.IdLoai.Equals(id));
            if (dsLoai == null)
            {
                return NotFound();
            }
            return Ok(dsLoai);
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model) 
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            } catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateNew(int id, LoaiModel loaiModel)
        {
            var dsLoai = _context.Loais.SingleOrDefault(loai => loai.IdLoai.Equals(id));
            if (dsLoai == null)
            {
                return NotFound();
            }
            dsLoai.TenLoai = loaiModel.TenLoai;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
