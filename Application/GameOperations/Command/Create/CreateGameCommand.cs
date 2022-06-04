using AutoMapper;
using GameStore.DbOperations;
using GameStore.Entities;

namespace GameStore.Application.GameOperations.Command.Create
{
    public class CreateGameCommand
    {
        private readonly GameStoreDbContext dbContext;
        private readonly IMapper mapper;
        public CreateGameModel Model { get; set; }

        public CreateGameCommand(GameStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Handler()
        {
            var gameCheck = dbContext.Games.SingleOrDefault(g=>g.Name==Model.Name);
            if(gameCheck is not null)
                throw new InvalidOperationException("Bu oyun zaten mevcut!");

            Game game = new();

            game.Name=Model.Name;
            game.Price=Model.Price;
            game.PublishDate=Model.PublishDate;

            List<GameGenre> gameGenres = new List<GameGenre>();
            List<GameDeveloper> gameDevelopers = new List<GameDeveloper>();
            List<GameWriter> gameWriters = new List<GameWriter>();

            foreach (var Genre_ID in Model.GameGenres)
                gameGenres.Add(new GameGenre{GameID=game.ID, GenreID=Genre_ID});

            foreach (var Developer_ID in Model.GameDevelopers)
                gameDevelopers.Add(new GameDeveloper{GameID=game.ID, DeveloperID=Developer_ID});

            foreach (var Writer_ID in Model.GameWriters)
                gameWriters.Add(new GameWriter{GameID=game.ID, WriterID= Writer_ID});

            game.GameGenres=gameGenres;
            game.GameDevelopers=gameDevelopers;
            game.GameWriters=gameWriters;

            dbContext.Games.Add(game);
            dbContext.SaveChanges();
        }
    }

    public class CreateGameModel
    {
        public string Name { get; set; }
        public Double Price { get; set; }
        public DateTime PublishDate { get; set; }
        public List<int> GameGenres { get; set; }
        public List<int> GameDevelopers { get; set; }
        public List<int> GameWriters { get; set; }
    }
}