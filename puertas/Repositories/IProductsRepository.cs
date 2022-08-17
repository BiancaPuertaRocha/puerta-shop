using puertas.Models;
using System;
using System.Collections.Generic;

namespace puertas.Repositories
{
    public interface IProductsRepository
    {
        Product GetProduct(Guid Id);
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product product);
    }
}