using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DbOperations
{
    public interface IGameDbStoreContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Game> GamePublishers { get; set; }
        int SaveChanges();
    }
}