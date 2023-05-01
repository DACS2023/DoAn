using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using DoAnCoSo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCoSo.Areas.Admin.Pages.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;

        protected readonly QuanLyHoiThaoDBContext _context;

        [TempData]
        public string StatusMessage { get; set; } = "";
        public QuanLyHoiThaoDBContext QuanLyHoiThaoDBContext { get; }

        public RolePageModel(RoleManager<IdentityRole> roleManager, QuanLyHoiThaoDBContext quanLyHoiThaoDBContext)
        {
            _roleManager = roleManager;
            _context = quanLyHoiThaoDBContext;
        }

        public RolePageModel(QuanLyHoiThaoDBContext quanLyHoiThaoDBContext)
        {
            QuanLyHoiThaoDBContext = quanLyHoiThaoDBContext;
        }
        public IActionResult OnPost() => NotFound("Không thấy");
    }
}
