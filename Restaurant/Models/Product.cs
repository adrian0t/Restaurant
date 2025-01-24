using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Models
{
    public class Product
    {
        public Product()
        {
            ProductIngredients = new List<ProductIngredient>();
        }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Opis jest wymagany.")]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        [Range(1, 110, ErrorMessage = "Musi być pomiędzy 1 a 100")]
        public int Stock { get; set; }

        public int CategoryId { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/150";

        
         public Category? Category { get; set; } 

        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; } 

        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; } 
    }
}