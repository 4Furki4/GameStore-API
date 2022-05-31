namespace GameStore.Entities
{
    public class GameDeveloper
    {
        public int ID{ get; set; }
        public int GameID { get; set; }
        public List<Game> MyProperty { get; set; }
        public int DeveloperID { get; set; }
        public List<Developer> Developer { get; set; }
    }
}