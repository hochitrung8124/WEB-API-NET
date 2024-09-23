namespace MyWebAPIApp.data
{
    public class ChiTietDonHang
    {
        public Guid Id { get; set; } // mã hàng hóa
        public Guid MaDH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia{ get; set; }
        public byte GiamGia{ get; set; }
        
        //relationship
        public DonHang DonHang{ get; set; }
        public HangHoa HangHoa{ get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
