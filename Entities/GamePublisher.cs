namespace GameStore.Entities
{
    public class GamePublisher
    {
        public int ID { get; set; }
        public int GameId { get; set; }
        public List<Game> Game { get; set; }
        public int PublishedId { get; set; }
        public List<Publisher> Publisher { get; set; }
    }
}