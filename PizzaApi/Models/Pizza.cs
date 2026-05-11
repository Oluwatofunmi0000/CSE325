using System.ComponentModel.DataAnnotations;

namespace PizzaApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}