using Backend.Application.Common.Exceptions;
using Backend.Application.Common.Interfaces;
using Backend.Application.Common.Models;
using Backend.Application.Dto;
using Backend.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.Commands.Delete
{
    public class DeletePostCommand : IRequestWrapper<PostDto>
    {
        public int Id { get; set; }
    }

    public class DeletePostCommandHandler : IRequestHandlerWrapper<DeletePostCommand, PostDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PostDto>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            _context.Posts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<PostDto>(entity));
        }
    }
}