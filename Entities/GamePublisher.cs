using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class GamePublisher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int PublishedId { get; set; }
        public Publisher Publisher { get; set; }
    }
}