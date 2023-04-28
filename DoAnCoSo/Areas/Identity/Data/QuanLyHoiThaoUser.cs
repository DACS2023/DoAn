using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoAnCoSo.Areas.Identity.Data;

// Add profile data for application users by adding properties to the QuanLyHoiThaoUser class
public class QuanLyHoiThaoUser : IdentityUser
{

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    
    public string gender;
    public string Gender { get => gender; set => gender = value; }

    [Required]
    [Column(TypeName = "Date")]
    public DateTime Birthday { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(500)")]
    public string Address { get; set; }

    
}

