﻿using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DoAnCoSo.Areas.Admin.Pages.Role
{
    //[Authorize(Roles = "Admin")]

    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, QuanLyHoiThaoDBContext quanLyHoiThaoDBContext) : base(roleManager, quanLyHoiThaoDBContext)
        {
        }

        public class RoleModel : IdentityRole
        {
            public string[] Claims { get; set; }
        }
        public List<RoleModel> roles { set; get; }

        public async Task OnGet()
        {
            // _roleManager.GetClaimsAsync()
            var r = await _roleManager.Roles.OrderBy(r => r.Name).ToListAsync();
            roles = new List<RoleModel>();
            foreach (var _r in r)
            {
                var claims = await _roleManager.GetClaimsAsync(_r);
                var claimsString = claims.Select(c => c.Type + "=" + c.Value);

                var rm = new RoleModel()
                {
                    Name = _r.Name,
                    Id = _r.Id,
                    Claims = claimsString.ToArray()
                };
                roles.Add(rm);
            }


        }

        public void OnPost() => RedirectToPage();
    }
}