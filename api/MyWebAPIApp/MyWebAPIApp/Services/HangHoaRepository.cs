using MyWebAPIApp.data;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Services
{
    public class HangHoaRepository : IHangHoa
    {
        private MyDBContext _context;

        public HangHoaRepository(MyDBContext myDBContext) 
        {
            _context = myDBContext;
        }
        public List<HangHoaModel> GetAll(string? search)
        {
            var allProducts = _context.HangHoas.AsQueryable();
            if(!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHangHoa.Contains(search));
            }
            var result = allProducts.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.Id,
                TenHangHoa = hh.TenHangHoa,
                Gia = hh.DonGia,
            });

            return result.ToList();
        }
    }
}
