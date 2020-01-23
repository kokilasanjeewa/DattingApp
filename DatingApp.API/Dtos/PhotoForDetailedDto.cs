using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class PhotoForDetailedDto
    {
    public int Id { set; get; }

    public string Url { set; get; }

    public string Description { set; get; }
    [Display(Name = "Photo Added")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateAdded { get; set; }

    public bool IsMain { get; set; }
    public int UserId { get; set; }
    }
}