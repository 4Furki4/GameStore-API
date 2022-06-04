using AutoMapper;
using GameStore.Application.GameOperations.Command.Create;
using GameStore.Application.GameOperations.Query.GetBookDetail;
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
            .ForMember(dest => dest.Genres,opt => opt.MapFrom(src => src.GameGenres.Select(n=>n.Genre.Name)))
            .ForMember(dest=>dest.Writers,opt=>opt.MapFrom(src=>src.GameWriters.Select(s=>s.Writer.Name).ToList()));

            CreateMap<Game, GameDetailModel>()
            .ForMember(dest => dest.Developers,opt => opt.MapFrom(src => src.GameDevelopers.Select(n => n.Developer.Name).ToList()))
            .ForMember(dest => dest.Genres,opt => opt.MapFrom(src => src.GameGenres.Select(n=>n.Genre.Name)))
            .ForMember(dest=>dest.Writers,opt=>opt.MapFrom(src=>src.GameWriters.Select(s=>s.Writer.Name).ToList()));

            // CreateMap<CreateGameModel,Game>()
            // .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name))
            // .ForMember(dest=>dest.Price,opt=>opt.MapFrom(src=>src.Price))
            // .ForMember(dest=>dest.PublishDate,opt=>opt.MapFrom(src=>src.PublishDate));
            // .ForPath(dest=>dest.GameGenres.Select(g=>g.GenreID),opt=>opt.MapFrom(src=>src.GameGenres))
            // .ForPath(dest=>dest.GameDevelopers.Select(g=>g.DeveloperID),opt=>opt.MapFrom(src=>src.GameDevelopers))
            // .ForPath(dest=>dest.GameWriters.Select(g=>g.WriterID),opt=>opt.MapFrom(src=>src.GameWriters))
        }
    }
}