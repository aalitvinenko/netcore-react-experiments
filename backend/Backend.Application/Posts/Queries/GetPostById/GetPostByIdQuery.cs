using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Models;
using Backend.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequestWrapper<PostDto>
    {
        public int PostId { get; set; }
    }

    public class GetPostByIdQueryHandler : IRequestHandlerWrapper<GetPostByIdQuery, PostDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PostDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .Where(x => x.Id == request.PostId)
                .ProjectToType<PostDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return post != null ? ServiceResult.Success(post) : ServiceResult.Failed<PostDto>(ServiceError.NotFount);
        }
    }
}