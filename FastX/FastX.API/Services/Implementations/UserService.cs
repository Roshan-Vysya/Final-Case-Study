using FastX.DAL.DataAccess.Interfaces;
using FastX.DAL.Models;
using FastX.API.Helpers;
using FastX.API.Services.Interfaces;

namespace FastX.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user != null && user.PasswordHash == password;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || user.PasswordHash != password)
                return null;

            return _jwtTokenGenerator.GenerateToken(user);
        }

        public async Task<bool> RegisterUserAsync(User user) // ✅ Implementation added
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
                return false;

            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null) return;

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;

            _userRepository.Update(existingUser);
            await _userRepository.SaveAsync();
        }


        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                await _userRepository.SaveAsync();
            }
        }

    }
}
