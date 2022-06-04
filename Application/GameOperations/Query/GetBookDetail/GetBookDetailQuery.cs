using AutoMapper;
using GameStore.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.GameOperations.Query.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly GameStoreDbContext dbContext;
        private readonly IMapper mapper;
        public int GameID { get; set; }
        public GetBookDetailQuery(GameStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public GameDetailModel Handler()
        {
            var game = dbContext.Games
            .Include(x=>x.GameWriters).ThenInclude(w=>w.Writer)
            .Include(x=>x.GameDevelopers).ThenInclude(x=>x.Developer)
            .Include(x=>x.GameGenres).ThenInclude(x=>x.Genre)
            .SingleOrDefault(x=>x.ID==GameID);

            if(game is null)
                throw new InvalidOperationException("Girmiş olduğunuz ID ile eşleşen oyun bulunamadı!");

            var result = mapper.Map<GameDetailModel>(game);
            return result;
        }
    }

    public class GameDetailModel
    {
        public string Name { get; set; }
        public Double Price { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Writers { get; set; }
    }
}