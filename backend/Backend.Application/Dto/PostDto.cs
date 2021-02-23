using Backend.Domain.Entities;
using Mapster;

namespace Backend.Application.Dto
{
    public class PostDto : IRegister
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string CreateDate { get; set; }

        public bool Published { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Post, PostDto>()
            .Map(dest => dest.CreateDate,
                src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}