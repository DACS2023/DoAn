using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.VisualBasic;
using DoAnCoSo.Areas.Identity.Data;

namespace DoAnCoSo.Areas.Identity.Data
{
    public class TranDau
    {
        [Key]
        [DisplayName("Id Trân Đấu")]
        [Column(TypeName = "int")]
        public int IdTranDau { get; set; }

        [DisplayName("Tên Trận Đấu")]
        [Column(TypeName = "nvarchar(100)")]
        public string Tentrandau { get; set; } = null!;

        [DisplayName("Đội 1")]
        [Column(TypeName = "int")]
        public int IdDoi1 { get; set; }

        [DisplayName("Đội 2")]
        [Column(TypeName = "int")]
        public int IdDoi2 { get; set; }

        [DisplayName("Trạng thái")]
        [Column(TypeName = "bit")]
        public bool Trangthai { get; set; }

        [DisplayName("Thời gian bắt đầu")]
        [Column(TypeName = "Datetime")]
        public DateTime Thoigianbatdau { get; set; }

        [DisplayName("Kết quả")]
        [Column(TypeName = "varchar(50)")]
        public String? Tiso { get; set; }

        public virtual Doi Doi1 { get; set; }

        public virtual Doi Doi2 { get; set; }
    }
}
