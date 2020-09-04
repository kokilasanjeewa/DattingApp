using System;

namespace DatingApp.API.Models
{
  public class Account
  {
    public Guid Id { get; set; }
    public TypeOfAccount Type { get; set; }
    public string Description { get; set; }
  }
}