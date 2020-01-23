using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender {get;set;}
        public int Age {get;set;} 
        public string KnownAs {get;set;}
        [Display(Name = "Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created {get;set;} 
        [Display(Name = "Last Active")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastActive {get;set;}
        public string city {get;set;}
        public string Country {get;set;}

        public string PhotoUrl {get;set;}
    }
}