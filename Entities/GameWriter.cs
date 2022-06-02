using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class GameWriter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
    }
}