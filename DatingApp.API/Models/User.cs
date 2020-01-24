using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.API.Models
{
  public class User : IdentityUser<int>
  {
    public string Gender { get; set; }
    [Display(Name = "Date Of Birth")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }

    public string KnownAs { get; set; }
    [Display(Name = "Created")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Created { get; set; }
    [Display(Name = "Last Active")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime LastActive { get; set; }

    public string Introduction { get; set; }

    public string LookingFor { get; set; }

    public string Interrests { get; set; }

    public string city { get; set; }

    public string Country { get; set; }

    public virtual ICollection<Photo> Photos { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; }
  }
}