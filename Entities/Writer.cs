using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class Writer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}