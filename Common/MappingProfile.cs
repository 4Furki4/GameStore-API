using AutoMapper;
using GameStore.Application.GameOperations.Query.GetBooks;
using GameStore.Entities;

namespace GameStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Game, GameModel>()
            .ForMember(dest => dest.Developers,opt => opt.MapFrom(src => src.GameDevelopers.Select(n => n.Developer.Name).ToList()))
            .ForMember(dest => dest.Publishers,opt => opt.MapFrom(src => src.GamePublisher.Select(n => n.Publisher.Name).ToList()))
            .ForMember(dest => dest.Genres,opt => opt.MapFrom(src => src.GameGenres.Select(n=>n.Genre.Name)))
            .ForMember(dest=>dest.Writers,opt=>opt.MapFrom(src=>src.GameWriters.Select(s=>s.Writer.Name).ToList()));
        }
    }
}