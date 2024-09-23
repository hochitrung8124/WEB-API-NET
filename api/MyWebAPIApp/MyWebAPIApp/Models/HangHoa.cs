namespace MyWebAPIApp.Models
{
    public class HangHoaVM
    {
        public Guid Id { get; set; }
    }
    public class HangHoa : HangHoaVM
    {
        public string? TenHangHoa { get; set; }
        public double? Gia { get; set; }
    }

}
