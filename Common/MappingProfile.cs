using AutoMapper;
using GameStore.Application.GameOperations.Command.Update;
using GameStore.Application.GameOperations.Query.GetGameDetail;
using GameStore.Application.GameOperations.Query.GetGames;
using GameStore.Application.GenreOperations.Query.GetDetail;
using GameStore.Entities;
using GameStore.Application.GenreOperations.Query.Get;
using GameStore.Application.GenreOperations.Command.Create;

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

            CreateMap<UpdateGameModel,Game>();

            CreateMap<Genre,GenreViewModel>();

            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<CreateGenreModel, Genre>();
        }
    }
}