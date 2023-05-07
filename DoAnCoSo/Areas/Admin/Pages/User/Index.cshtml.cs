using DoAnCoSo.Areas.Admin.Pages.Role;
using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DoAnCoSo.Areas.Admin.Pages.User
{
    //[Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly UserManager<QuanLyHoiThaoUser> _userManager;
        public IndexModel(UserManager<QuanLyHoiThaoUser> userManager, QuanLyHoiThaoDBContext quanLyHoiThaoDBContext)
        {
            _userManager = userManager;
        }

        public string StatusMessage { get; set; }
        public List<QuanLyHoiThaoUser> users { set; get; }

        public async Task OnGet()
        {
            users = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();

        }

        public void OnPost() => RedirectToPage();
    }
}