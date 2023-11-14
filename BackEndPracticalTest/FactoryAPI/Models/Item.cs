using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FactoryAPI.Models
{
    //our model describing item based off which we will create our database schema
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descritpion { get; set; }
        public decimal Price { get; set; }
    }
}
