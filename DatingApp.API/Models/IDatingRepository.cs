using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Models
{
    public interface IDatingRepository
    {
            Task AddAsync(User user);
            Task DeleteAsync(User user);
            Task<IEnumerable<User>> GetUsersAsync();
            Task<User> GetUserAsync(int id);

            Task<bool> SaveAllAsync();
    }
}