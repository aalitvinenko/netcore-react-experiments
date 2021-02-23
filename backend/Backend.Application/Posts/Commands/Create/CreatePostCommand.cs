using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Models;
using Backend.Application.Dto;
using Backend.Domain.Entities;
using Backend.Domain.Event;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.Commands.Create
{
    public class CreatePostCommand : IRequestWrapper<PostDto>
    {
        public string Description { get; set; }
    }

    public class CreatePostCommandHandler : IRequestHandlerWrapper<CreatePostCommand, PostDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PostDto>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = new Post
            {
                Description = request.Description
            };

            entity.DomainEvents.Add(new PostCreatedEvent(entity));

            await _context.Posts.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<PostDto>(entity));
        }
    }
}