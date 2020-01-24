using System;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      DateTime date = new DateTime().Date;
      //byte[] passwordHash, passwordSalt;
      //CreatePasswordHash("password", out passwordHash, out passwordSalt);
      modelBuilder.Entity<User>().HasData(new User
      {
        Id=1,  
        UserName = "kokila.sanjeewa@gmail.com",
        city = "Colombo",
        Country = "Sri Lanka",
        Created = date,
        DateOfBirth = date,
        Gender = "Male",
        Interrests = "Codeing",
        Introduction = "Anything is Possible and Nothing is Impossible",
        KnownAs = "active",
        LastActive = date,
        LookingFor = "Don't reinvent the wheel,unless you plan on learning more about wheels",
      }
      ); 
      modelBuilder.Entity<Photo>().HasData(
          new Photo
          {
            Id=1,
            DateAdded = date,
            Description = "https://randomuser.me/",
            Url = "https://randomuser.me/api/portraits/men/75.jpg",
            UserId = 1,
            IsMain = true

          }

      );
    }
     public static void SeedNew(UserManager<User> userManager)
    {
         DateTime date = new DateTime().Date;
         User user = new User {
        Id=1,  
        UserName = "kokila.sanjeewa@gmail.com",
        city = "Colombo",
        Country = "Sri Lanka",
        Created = date,
        DateOfBirth = date,
        Gender = "Male",
        Interrests = "Codeing",
        Introduction = "Anything is Possible and Nothing is Impossible",
        KnownAs = "active",
        LastActive = date,
        LookingFor = "Don't reinvent the wheel,unless you plan on learning more about wheels",
      };
      userManager.CreateAsync(user).Wait();
    }
    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        //convert text password to computed password hash
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}