using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
  public class Owner
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public ICollection<Account> Accounts { get; set; }
  }
}