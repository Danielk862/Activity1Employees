using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.Shared.Dtos;
using Employee.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class UsersUnitOfWork : IUsersUnitOfWork
    {
        private readonly IUsersRepository _usersRepository;
        public UsersUnitOfWork(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password) => await _usersRepository.AddUserAsync(user, password);

        public async Task AddUserToRoleAsync(User user, string roleName) => await _usersRepository.AddUserToRoleAsync(user, roleName);

        public async Task CheckRoleAsync(string roleName) => await _usersRepository.CheckRoleAsync(roleName);

        public async Task<User> GetUserAsync(string email) => await _usersRepository.GetUserAsync(email);

        public async Task<bool> IsUserInRoleAsync(User user, string roleName) => await _usersRepository.IsUserInRoleAsync(user, roleName);

        public async Task<SignInResult> LoginAsync(LoginDto model) => await _usersRepository.LoginAsync(model);

        public async Task LogOutAsync() => await _usersRepository.LogOutAsync();
        public async Task<User> GetUserAsync(Guid userId) => await _usersRepository.GetUserAsync(userId);
        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword) => await _usersRepository.ChangePasswordAsync(user, currentPassword, newPassword);
        public async Task<IdentityResult> UpdateUserAsync(User user) => await _usersRepository.UpdateUserAsync(user);
    }
}
