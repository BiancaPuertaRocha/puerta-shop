using Microsoft.AspNetCore.Mvc;
using puertas.Repositories;
using puertas.Models;

namespace puertas.Controllers
{   
    [ApiController]
    [Route("products")]
    //[Route("[controller]")]
    public class ProductsController : ControllerBase{
        private readonly ProductsRepository repository;

        public ProductsController(){
            repository = new ProductsRepository();
        }

        //GET /products
        [HttpGet]
        public IEnumerable<Product> GetProducts(){
            var products = repository.GetProducts();
            return products;
        }
    }
}