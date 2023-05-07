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

    
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string User { get; set; }

    public string gender;
    public string Gender { get => gender; set => gender = value; }

    
    [Column(TypeName = "Date")]
    public DateTime Birthday { get; set; }

    
    [Column(TypeName = "nvarchar(500)")]
    public string Address { get; set; }

    
}

