using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnCoSo.ViewModel
{
    public class GiaiDauCreateModel
    {
        public GiaiDau giaiDau { get; set; }
        public IEnumerable<SelectListItem> loaigiaidau { get; set; }

    }
}
