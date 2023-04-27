using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Areas.Identity.Data
{
    public class LoaiGiaiDau
    {
        [Key]
        [DisplayName("Id Loại Giải")]
        [Column(TypeName = "int")]
        public int IdloaiGiaiDau { get; set; }

        [DisplayName("Tên Loại Giải Đấu")]
        [Column(TypeName = "nvarchar(100)")]
        public string TenLoai { get; set; } = null!;
        [DisplayName("Trạng Thái")]
        [Column(TypeName = "bit")]
        public bool TrangThai { get; set; }

        public virtual ICollection<GiaiDau> GiaiDaus { get; set; } = new List<GiaiDau>();
    }
}
