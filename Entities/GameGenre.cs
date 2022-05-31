namespace GameStore.Entities
{
    public class GameGenre
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public List<Game> Game { get; set; }
        public int GenreID { get; set; }
        public List<Genre> Genre { get; set; }
    }
}