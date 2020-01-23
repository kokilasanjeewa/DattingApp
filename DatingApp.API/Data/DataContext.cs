using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Seed();
    }
    public DbSet<Value> Values { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Photo> Photos { get; set; }
  }
}