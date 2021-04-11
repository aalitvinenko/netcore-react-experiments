using Backend.Application.Dto;

namespace Backend.Application.ApplicationUser.Commands.CreateUser
{
    public class CreateUserResponse
    {
        public ApplicationUserDto User { get; set; }

        public string Token { get; set; }
    }
}