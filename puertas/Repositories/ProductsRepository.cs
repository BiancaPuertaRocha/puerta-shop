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

        public void CreateProduct(Product product)
        {
            products.Add(product);
        }

        public bool DeleteProduct(Guid Id){
            Product prod = products.Where(product => product.Id == Id).SingleOrDefault();
            if (prod is not null){
                products.Remove(prod);
                return true;
            }
            return false;
        }

        public void UpdateProduct(Product product){
            var index = products.FindIndex(ex_item => ex_item.Id == product.Id);
            products[index] = product;
        }
    }
}