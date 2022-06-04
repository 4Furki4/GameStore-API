using GameStore.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.GameOperations.Command.Delete
{
    public class DeleteGameCommand
    {
        private readonly GameStoreDbContext dbContext;
        public int GameID { get; set; }

        public DeleteGameCommand(GameStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Handler()
        {
            var game = dbContext.Games
            .Include(g=>g.GameDevelopers).ThenInclude(g=>g.Developer)
            .Include(g=>g.GameGenres).ThenInclude(g=>g.Genre)
            .Include(g=>g.GameWriters).ThenInclude(g=>g.Writer)
            .SingleOrDefault(g=>g.ID==GameID);
            if(game is null)
                throw new InvalidOperationException("Silmek istediğiniz oyun bulunamadı!");
            dbContext.GameDevelopers.RemoveRange(game.GameDevelopers);
            dbContext.GameGenres.RemoveRange(game.GameGenres);
            dbContext.GameWriters.RemoveRange(game.GameWriters);
            dbContext.Games.Remove(game);
            dbContext.SaveChanges();
        }
    }
}