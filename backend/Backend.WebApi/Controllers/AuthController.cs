using Backend.Application.ApplicationUser.Commands.CreateUser;
using Backend.Application.ApplicationUser.Queries.GetToken;
using Backend.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.WebApi.Controllers
{
    /// <summary>
    /// User authentication and registration controller
    /// </summary>
    public class AuthController : BaseApiController
    {
        /// <summary>
        /// Register a new user and return a token
        /// </summary>
        /// <param name="command">User creation command</param>
        /// <returns>If succeeded, returns user information and token</returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResult<CreateUserResponse>>> SignUp(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Log user in and return a token
        /// </summary>
        /// <param name="query">Login query</param>
        /// <returns>If succeeded, returns user information and token</returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> SignIn(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}