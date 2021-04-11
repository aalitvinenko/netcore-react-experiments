using Backend.Application.Common.Models;
using Backend.Application.Dto;
using System.Threading.Tasks;

namespace Backend.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUserDto> CheckUserPassword(string emailOrUserName, string password);

        Task<(Result Result, ApplicationUserDto User)> CreateUserAsync(string userName, string email, string password);

        Task<bool> UserIsInRole(string userId, string role);

        Task<Result> DeleteUserAsync(string userId);
    }
}