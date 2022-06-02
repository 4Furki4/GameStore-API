using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class GameDeveloper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID{ get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
    }
}