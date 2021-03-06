using System;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    public AuthRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<User> Login(string username, string password)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
      if (user == null)
      {
        return null;
      }
     /* if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
      {
        return null;
      }*/
      return user;
    }
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        //convert text password to computed hash
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {

          if (computedHash[i] != passwordHash[i])
          {
            return false;
          }

        }

      }
       
      return true;
    }
     public async Task<User> Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
      return user;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {

        passwordSalt = hmac.Key;
        //convert text password to computed password hash
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

      }
    }
    public async Task<bool> UserExists(string username)
    {
      if (await _context.Users.AnyAsync(u => u.UserName == username))
      {
        return true;
      }
      return false;
    }
  }
}