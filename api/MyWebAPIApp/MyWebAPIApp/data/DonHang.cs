namespace MyWebAPIApp.data
{
    public enum TinhTrangDonHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDH {  get; set; }
        public DateTime NgayDatHang {  get; set; }
        public DateTime NgayGiaoHang {  get; set; }
        public TinhTrangDonHang TinhTrangDonHang {  get; set; }
        public string NguoiNhan {  get; set; }
        public string DiaChi {  get; set; }
        public string Sdt {  get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DonHang()
        {
            ChiTietDonHangs = new List<ChiTietDonHang>();
        }
    }
}
