using Backend.Application.Common.Models;
using Backend.Application.Common.Security;
using Backend.Application.Dto;
using Backend.Application.Posts.Commands.Create;
using Backend.Application.Posts.Commands.Delete;
using Backend.Application.Posts.Commands.Update;
using Backend.Application.Posts.Queries.GetPostById;
using Backend.Application.Posts.Queries.GetPosts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.WebApi.Controllers
{
    [Authorize]
    public class PostsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<PostDto>>>> GetAllCities(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllPostsQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<PostDto>>> GetPostById(int id)
        {
            return Ok(await Mediator.Send(new GetPostByIdQuery { PostId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<PostDto>>> Create(CreatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<PostDto>>> Update(UpdatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<PostDto>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePostCommand { Id = id }));
        }
    }
}