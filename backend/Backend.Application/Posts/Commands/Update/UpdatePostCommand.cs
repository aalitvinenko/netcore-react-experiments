using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Models;
using Backend.Application.Dto;
using Backend.Domain.Entities;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.Commands.Update
{
    public class UpdatePostCommand : IRequestWrapper<PostDto>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Published { get; set; }
    }

    public class UpdatePostCommandHandler : IRequestHandlerWrapper<UpdatePostCommand, PostDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PostDto>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                entity.Description = request.Description;
            }

            entity.Published = request.Published;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<PostDto>(entity));
        }
    }
}