namespace GameStore.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Developer> Developers { get; set; }

    }
}