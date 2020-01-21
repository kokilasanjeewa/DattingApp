using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Controllers
{
  public class UserForLogOnDto
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
  }
}