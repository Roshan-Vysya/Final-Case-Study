using FastX.DAL.Models;
using FastX.DAL.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX.DAL.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FastXContext _context;

        public async Task SaveAsync() => await _context.SaveChangesAsync();


        public UserRepository(FastXContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); // ✅ Save to DB
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges(); // optional — used during DeleteUser
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges(); // optional
        }
    }
}
