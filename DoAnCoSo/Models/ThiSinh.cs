using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSo.Areas.Identity.Data
{
    public class ThiSinh : QuanLyHoiThaoUser
    {
        [DisplayName("Bộ môn thi đấu")]
        [Column(TypeName = "nvarchar(100)")]
        public string BomonThiDau { get; set; }

        [DisplayName("Đội bóng")]
        public int IdDoi { get; set; }
        [ForeignKey("IdDoi")]

        public virtual Doi Doi { get; set; }
    }
}