using System.ComponentModel.DataAnnotations;
namespace puertas.Dtos{
    public record CreateProductDto{
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}