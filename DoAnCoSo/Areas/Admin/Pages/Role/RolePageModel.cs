using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using DoAnCoSo.Models;
using DoAnCoSo.Areas.Identity.Data;
//using DoAnCoSo.Areas.Areas.Identity.Data;

namespace DoAnCoSo.Areas.Admin.Pages.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly QuanLyHoiThaoDBContext _context;

        [TempData]
        public string StatusMessage { get; set; }
        public RolePageModel(RoleManager<IdentityRole> roleManager, QuanLyHoiThaoDBContext myBlogContext)
        {
            _roleManager = roleManager;
            _context = myBlogContext;
        }
    }
}