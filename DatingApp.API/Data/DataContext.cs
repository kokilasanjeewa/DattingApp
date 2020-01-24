using System.Net.NetworkInformation;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
  public class DataContext : IdentityDbContext<User,Role,int,IdentityUserClaim<int>,UserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      //modelBuilder.Seed();
      modelBuilder.Entity<UserRole>(userRole => {
        userRole.HasKey(ur => new {ur.UserId,ur.RoleId});
        userRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
        userRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();

      });
    }
    public DbSet<Value> Values { get; set; }
    public DbSet<Photo> Photos { get; set; }
  }
}