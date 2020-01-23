using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models
{
    public class DatingRepository:IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context=context;
        }
        public async Task AddAsync(User user)
        {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
        }
         public async Task DeleteAsync(User user)
        {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserAsync(int id)
        {
                User user =await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users =await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0 ;
        }
    }
}