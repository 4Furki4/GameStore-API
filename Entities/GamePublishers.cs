using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class GamePublishers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}