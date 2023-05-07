using DoAnCoSo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System;
using Xunit.Sdk;
using DoAnCoSo.Areas.Identity.Data;

namespace DoAnCoSo.Areas.Admin.Pages.User
{
    public class EditUserRoleClaimModel : PageModel
    {
        private readonly QuanLyHoiThaoDBContext _context;
        private readonly UserManager<QuanLyHoiThaoUser> _userManager;
        public EditUserRoleClaimModel(QuanLyHoiThaoDBContext quanLyHoiThaoDBContext, UserManager<QuanLyHoiThaoUser> userManager)
        {
            _context = quanLyHoiThaoDBContext;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public NotFoundObjectResult OnGet() => NotFound("Không được truy cập");

        public class InputModel
        {
            [Display(Name = "Kiểu (tên) claim")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string ClaimType { get; set; }

            [Display(Name = "Giá trị")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string ClaimValue { get; set; }
        }

        [BindProperty]
        public InputModel Input { set; get; }

        public QuanLyHoiThaoUser User { get; set; }

        public async Task<IActionResult> OnGetAddClaimAsync(string UserId)
        {
            User = await _userManager.FindByIdAsync(UserId);
            if (User == null) return NotFound("Không tìm thấy user");
            return Page();
        }
        public async Task<IActionResult> OnPostAddClaimAsync(string userid)
        {
            User = await _userManager.FindByIdAsync(userid);
            if (User == null) return NotFound("Không tìm thấy user");

            if (!ModelState.IsValid) return Page();
            var claims = _context.UserClaims.Where(c => c.UserId == User.Id);

            if (claims.Any(c => c.ClaimType == Input.ClaimType && c.ClaimValue == Input.ClaimValue))
            {
                ModelState.AddModelError(string.Empty, "Đặc tính này đã có");
                return Page();
            }

            await _userManager.AddClaimAsync(User, new Claim(Input.ClaimType, Input.ClaimValue));
            StatusMessage = "Đã thêm đặc tính cho user";
            return RedirectToPage("./AddRole", new { User.Id });
        }

        public IdentityUserClaim<string> userclaim { get; set; }

        public async Task<IActionResult> OnGetEditClaimAsync(int? claimid)
        {
            if (claimid == null) return NotFound("Không tìm thấy user");

            userclaim = _context.UserClaims.Where(c => c.Id == claimid).FirstOrDefault();
            User = await _userManager.FindByIdAsync(userclaim.UserId);

            if (User == null) return NotFound("Không tìm thấy user");

            Input = new InputModel()
            {
                ClaimType = userclaim.ClaimType,
                ClaimValue = userclaim.ClaimValue

            };

            return Page();
        }
        public async Task<IActionResult> OnPostEditClaimAsync(int? claimid)
        {
            if (claimid == null) return NotFound("Không tìm thấy user");

            userclaim = _context.UserClaims.Where(c => c.Id == claimid).FirstOrDefault();
            User = await _userManager.FindByIdAsync(userclaim.UserId);

            if (User == null) return NotFound("Không tìm thấy user");

            if (!ModelState.IsValid) return Page();

            if (_context.UserClaims.Any(c => c.UserId == User.Id
                && c.ClaimType == Input.ClaimType
                && c.ClaimValue == Input.ClaimValue
                && c.Id != userclaim.Id))
            {
                ModelState.AddModelError(string.Empty, "Claim này đã có");
                return Page();
            }


            userclaim.ClaimType = Input.ClaimType;
            userclaim.ClaimValue = Input.ClaimValue;

            await _context.SaveChangesAsync();
            StatusMessage = "Bạn vừa cập nhật claim";

            return RedirectToPage("./AddRole", new { User.Id });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? claimid)
        {
            if (claimid == null) return NotFound("Không tìm thấy user");

            userclaim = _context.UserClaims.Where(c => c.Id == claimid).FirstOrDefault();
            User = await _userManager.FindByIdAsync(userclaim.UserId);

            if (User == null) return NotFound("Không tìm thấy user");

            await _userManager.RemoveClaimAsync(User, new Claim(userclaim.ClaimType, userclaim.ClaimValue));

            StatusMessage = "Bạn đã xóa claim";

            return RedirectToPage("./AddRole", new { User.Id });
        }

    }
}
