using MyWebAPIApp.Models;

namespace MyWebAPIApp.Services
{
    public interface IHangHoa
    {
        List<HangHoaModel> GetAll(string search);
    }
}
