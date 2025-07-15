using FastX.DAL.Models;

namespace FastX.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(int id, User user);
        // ✅ Add this
        Task DeleteUserAsync(int id);             // ✅ Optional, for Delete support
        Task<bool> ValidateCredentialsAsync(string email, string password);
        Task<string?> LoginAsync(string email, string password);
        Task<bool> RegisterUserAsync(User user);
    }
}
