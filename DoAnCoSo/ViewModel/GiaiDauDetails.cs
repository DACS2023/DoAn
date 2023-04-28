using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnCoSo.ViewModel
{
    public class GiaiDauDetails
    {
        public GiaiDau giaiDau { get; set; }
        public LoaiGiaiDau loaigiaidau { get; set; }
    }
}
