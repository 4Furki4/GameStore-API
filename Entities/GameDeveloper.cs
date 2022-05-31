using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class GameDeveloper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID{ get; set; }
        public int GameID { get; set; }
        public List<Game> MyProperty { get; set; }
        public int DeveloperID { get; set; }
        public List<Developer> Developer { get; set; }
    }
}