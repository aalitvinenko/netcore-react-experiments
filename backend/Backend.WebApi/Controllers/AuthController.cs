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
        /// Log user in and return a token
        /// </summary>
        /// <param name="query">Login query</param>
        /// <returns>If succeeded, returns user information and token</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}