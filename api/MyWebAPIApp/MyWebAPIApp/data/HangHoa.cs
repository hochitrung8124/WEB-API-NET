using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPIApp.data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Id {  get; set; }
        [Required]
        [StringLength(50)]
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        [Range(0,double.MaxValue)]
        public double DonGia { get; set; }
        public byte  GiamGia { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public HangHoa()
        {
            ChiTietDonHangs = new List<ChiTietDonHang>();
        }
    }
}
