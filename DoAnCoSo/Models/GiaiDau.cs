using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Areas.Identity.Data
{
    
    public class GiaiDau 
    {
        [Key]
        [DisplayName("Id Giải Đấu")]
        [Column(TypeName = "int")]
        public int IdgiaiDau { get; set; }

        [DisplayName("Tên Giải Đấu")]
        [Column(TypeName = "nvarchar(100)")]
        public string TenGiaiDau { get; set; } = null!;

        [DisplayName("Loại Giải Đấu")]
        [Column(TypeName = "int")]
        public int IdloaiGiaiDau { get; set; }

        [DisplayName("Ngày Bắt Đầu")]
        [Column(TypeName = "Date")]
        public DateTime NgayBatDau { get; set; }

        [DisplayName("Ngày Kết Thúc")]
        [Column(TypeName = "Date")]
        public DateTime NgayKetThuc { get; set; }

        [DisplayName("Nội Dung")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string NoiDung { get; set; } = null!;

        [DisplayName("Trạng Thái")]
        [Column(TypeName = "bit")]
        public bool TrangThai { get; set; }

        public virtual ICollection<LoaiGiaiDau> ThiDaus { get; set; } = new List<LoaiGiaiDau>();
    }
}
