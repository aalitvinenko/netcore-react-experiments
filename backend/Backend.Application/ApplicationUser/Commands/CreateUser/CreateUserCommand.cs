using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.ApplicationUser.Commands.CreateUser
{
    public class CreateUserCommand : IRequestWrapper<CreateUserResponse>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, CreateUserResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public CreateUserCommandHandler(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        public async Task<ServiceResult<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var (result, user) = await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password);

            if (!result.Succeeded)
                return ServiceResult.Failed<CreateUserResponse>(ServiceError.UserFailedToCreate);

            return ServiceResult.Success(new CreateUserResponse
            {
                User = user,
                Token = _tokenService.CreateJwtSecurityToken(user.Id)
            });
        }
    }
}