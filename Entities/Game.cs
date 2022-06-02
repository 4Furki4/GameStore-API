using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public DateTime PublishDate { get; set; }
        public List<GameGenre> GameGenres { get; set; }
        // public List<GamePublisher> GamePublishers { get; set; }
        public List<GameDeveloper> GameDevelopers { get; set; }
        public List<GameWriter> GameWriters { get; set; }

    }
}