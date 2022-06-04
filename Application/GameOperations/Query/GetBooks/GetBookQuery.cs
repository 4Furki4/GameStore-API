using AutoMapper;
using GameStore.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.GameOperations.Query.GetBooks
{
    public class GetBookQuery
    {
        private readonly GameStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetBookQuery(GameStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<GameModel> Handler()
        {
            var game = dbContext.Games
            .Include(x=>x.GameWriters).ThenInclude(w=>w.Writer)
            .Include(x=>x.GameDevelopers).ThenInclude(x=>x.Developer)
            .Include(x=>x.GameGenres).ThenInclude(x=>x.Genre)
            .OrderBy(x=>x.ID).ToList();
            if(game is null)
                throw new InvalidOperationException("Oyun bulunamadı!");
            var result = mapper.Map<List<GameModel>>(game);
            return result;
        }
    }
    public class GameModel
    {
        public string Name { get; set; }
        public Double Price { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Writers { get; set; }
    }
}