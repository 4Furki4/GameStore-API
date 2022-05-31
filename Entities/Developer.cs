using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Entities
{
    public class Developer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}