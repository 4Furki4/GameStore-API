using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class GameGenre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GameID { get; set; }
        public List<Game> Game { get; set; }
        public int GenreID { get; set; }
        public List<Genre> Genre { get; set; }
    }
}