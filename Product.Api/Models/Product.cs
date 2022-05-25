using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [PositiveNumber(ErrorMessage = "Price must be positive;")]
        public decimal? Price { get; set; }

        [PositiveNumber(ErrorMessage = "Quantity must be positive;")]
        public int Quantity { get; set; }
        public string? Description { get; set; }

    }
}