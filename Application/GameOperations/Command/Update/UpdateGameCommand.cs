using AutoMapper;
using GameStore.DbOperations;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.GameOperations.Command.Update
{
    public class UpdateGameCommand
    {
        private readonly GameStoreDbContext dbContext;

        public UpdateGameModel Model { get; set; }
        public int GameID { get; set; }
        public UpdateGameCommand(GameStoreDbContext dbContext)
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
                throw new InvalidOperationException("Güncellemek istediğiniz kitap bulunamadı.");

            game.Name = Model.Name == string.Empty || Model.Name == "string" ? game.Name : Model.Name;
            game.Price = Model.Price == game.Price ? game.Price : Model.Price;
            game.PublishDate = Model.PublishDate == default ? game.PublishDate : Model.PublishDate;

            dbContext.SaveChanges();
        }
    }

    public class UpdateGameModel
    {
        public string Name { get; set; }
        public Double Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}