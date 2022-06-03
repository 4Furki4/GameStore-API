using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new GameStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<GameStoreDbContext>>()))
            {
                if(context.Games.Any())
                    return;
                context.Games.AddRange
                (
                    new Game
                    {
                        Name = "Red Dead Redemption 2", Price=59.99, PublishDate = new DateTime(2018,10,25)
                    },
                    new Game
                    {
                        Name = "XCOM 2", Price = 59.99, PublishDate = new DateTime(2016, 02,05)
                    }
                );

                if(context.Developers.Any())
                    return;
                context.Developers.AddRange
                (
                    new Developer {Name = "Rockstar Games"},
                    new Developer {Name = "Fraxis Games"},
                    new Developer {Name = "Feral Interactive"}
                );
                if(context.Genres.Any())
                    return;
                context.Genres.AddRange
                (
                    new Genre{Name = "Strategy"},
                    new Genre{Name = "Turn-Based"},
                    new Genre{Name = "Sci-fi"},
                    new Genre{Name = "Tactical"},
                    new Genre{Name = "Open World"},
                    new Genre{Name = "Adventure"},
                    new Genre{Name = "Action"},
                    new Genre{Name = "Western"},
                    new Genre{Name = "Shooter"}
                );
                if(context.Writers.Any())
                    return;
                context.Writers.AddRange
                (
                    new Writer{Name = "Dan Houser"},
                    new Writer{Name = "Benjamin Byron Davis"},
                    new Writer{Name = "Scott Wittbecker"}
                );
                context.GameDevelopers.AddRange(gameDevelopers);
                context.GameGenres.AddRange(gameGenres);
                context.GameWriters.AddRange(gameWriters);
                context.SaveChanges();
            }
        }
        
        static List<GameDeveloper> gameDevelopers = new List<GameDeveloper>
        {
            new GameDeveloper{GameID = 1, DeveloperID = 1},
            new GameDeveloper{GameID = 2, DeveloperID = 2},
            new GameDeveloper{GameID = 2, DeveloperID = 3}
        };
        static List<GameGenre> gameGenres = new List<GameGenre>
        {
            new GameGenre{GameID = 1, GenreID = 5},
            new GameGenre{GameID = 1, GenreID = 6},
            new GameGenre{GameID = 1, GenreID = 7},
            new GameGenre{GameID = 1, GenreID = 8},
            new GameGenre{GameID = 1, GenreID = 9},
            new GameGenre{GameID = 2, GenreID = 1},
            new GameGenre{GameID = 2, GenreID = 2},
            new GameGenre{GameID = 2, GenreID = 3},
            new GameGenre{GameID = 2, GenreID = 4}
        };
        static List<GameWriter> gameWriters = new List<GameWriter>
        {
            new GameWriter{GameID = 1, WriterID = 1},
            new GameWriter{GameID = 1, WriterID = 2},
            new GameWriter{GameID = 2, WriterID = 3}
        };
    }
}