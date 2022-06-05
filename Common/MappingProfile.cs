using AutoMapper;
using GameStore.Application.GameOperations.Command.Update;
using GameStore.Application.GameOperations.Query.GetGameDetail;
using GameStore.Application.GameOperations.Query.GetGames;
using GameStore.Application.GenreOperations.Query.GetDetail;
using GameStore.Entities;
using GameStore.Application.GenreOperations.Query.Get;
using GameStore.Application.GenreOperations.Command.Create;
using GameStore.Application.DeveloperOperations.Query.Get;
using GameStore.Application.DeveloperOperations.Query.GetDetail;
using GameStore.Application.DeveloperOperations.Command.Create;
using GameStore.Application.WriterOperations.Query.Get;
using GameStore.Application.WriterOperations.Query.GetDetail;
using GameStore.Application.WriterOperations.Command.Create;

namespace GameStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ******************** Game Mappings ********************
            CreateMap<Game, GameModel>()
            .ForMember(dest => dest.Developers,opt => opt.MapFrom(src => src.GameDevelopers.Select(n => n.Developer.Name).ToList()))
            .ForMember(dest => dest.Genres,opt => opt.MapFrom(src => src.GameGenres.Select(n=>n.Genre.Name)))
            .ForMember(dest=>dest.Writers,opt=>opt.MapFrom(src=>src.GameWriters.Select(s=>s.Writer.Name).ToList()));

            CreateMap<Game, GameDetailModel>()
            .ForMember(dest => dest.Developers,opt => opt.MapFrom(src => src.GameDevelopers.Select(n => n.Developer.Name).ToList()))
            .ForMember(dest => dest.Genres,opt => opt.MapFrom(src => src.GameGenres.Select(n=>n.Genre.Name)))
            .ForMember(dest=>dest.Writers,opt=>opt.MapFrom(src=>src.GameWriters.Select(s=>s.Writer.Name).ToList()));

            CreateMap<UpdateGameModel,Game>();

            // ******************** Genre Mappings ********************
            CreateMap<Genre,GenreViewModel>();

            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<CreateGenreModel, Genre>();

            // ******************** Developer Mappings ********************
            CreateMap<Developer,DeveloperViewModel>();

            CreateMap<Developer,DeveloperDetailViewModel>();

            CreateMap<CreateDeveloperModel,Developer>();

            // ******************** Writer Mappings ********************
            CreateMap<Writer,GetWriterViewModel>();

            CreateMap<Writer,GetWriterDetailViewModel>();

            CreateMap<CreateWriterModel, Writer>();
        }
    }
}