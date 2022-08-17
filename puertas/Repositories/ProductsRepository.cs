using puertas.Models;
namespace puertas.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = new()
        {
            new Product {Id = Guid.NewGuid(), Name = "sapato", Price  = 9, CreatedAt = DateTimeOffset.UtcNow},
            new Product {Id = Guid.NewGuid(), Name = "sapato2", Price  = 90},
            new Product {Id = Guid.NewGuid(), Name = "sapato3", Price  = 28}
        };

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProduct(Guid Id)
        {
            return products.Where(product => product.Id == Id).SingleOrDefault();
        }

    }
}