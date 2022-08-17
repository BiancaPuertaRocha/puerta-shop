using puertas.Dtos;
using puertas.Models;
namespace puertas{
    public static class Extensions{
        public static ProductDto AsDto(this Product product) {
            return new ProductDto{
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}