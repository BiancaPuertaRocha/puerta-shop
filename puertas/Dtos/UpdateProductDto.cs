using System.ComponentModel.DataAnnotations;
namespace puertas.Dtos{
    public record UpdateProductDto{
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}