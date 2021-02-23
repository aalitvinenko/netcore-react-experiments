using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Models;
using Backend.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.Queries.GetPosts
{
    public class GetAllPostsQuery : IRequestWrapper<List<PostDto>>
    {
    }

    public class GetPostsQueryHandler : IRequestHandlerWrapper<GetAllPostsQuery, List<PostDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<PostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            List<PostDto> list = await _context.Posts
                .ProjectToType<PostDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<PostDto>>(ServiceError.NotFount);
        }
    }
}