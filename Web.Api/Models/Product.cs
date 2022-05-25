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

        [PositiveNumber(ErrorMessage ="Quantity must be positive;")]
        public int Quantity { get; set; }
        public string? Description { get; set; }

    }
}

public class PositiveNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value != null)
        {
            var x = int.TryParse(value.ToString(), out var output);

            if (x != false)
            {
                if (output > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;

    }

}