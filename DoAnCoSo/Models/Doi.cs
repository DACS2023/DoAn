using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DoAnCoSo.Areas.Identity.Data;

namespace DoAnCoSo.Areas.Identity.Data
{
    public class Doi 
    {
        [Key]
        [DisplayName("Id Đội")]
        [Column(TypeName = "int")]
        public int IdDoi { get; set; }

        [DisplayName("Tên Đội")]
        [Column(TypeName = "nvarchar(100)")]
        public string TenDoi { get; set; }

        [DisplayName("Đơn vị")]
        [Column(TypeName = "nvarchar(200)")]
        public string Donvi { get; set; } //Đơn vị của đội ví dụ: Đơn vị Hutech, UEF, Hồng Bàng,....

        [DisplayName("Logo Đội")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Logo { get; set; } //Logo này có thể null

        [DisplayName("Thành viên")]
        [Column(TypeName = "nvarchar(450)")]
        public string Id { get; set; } //Id này là của User. Lấy từ QuanLyHoiThaoUser. Anh xem hợp lý không nhé.

       
        

    }
}
