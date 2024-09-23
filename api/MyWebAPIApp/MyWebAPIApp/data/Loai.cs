using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPIApp.data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int IdLoai { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
