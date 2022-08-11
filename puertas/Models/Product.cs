using System;
namespace puertas.Models{
    public record Product
    {
        public Guid Id { get; init; } //only allow set a value when it is created
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        
    }
}