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

        //GET /product/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(Guid id){
            //ActionResult permite retornar o objeto encontrado ou o status
            var product = repository.GetProduct(id);
            if (product is null){
                return NotFound();
            }
            return Ok(product);
            //return product; aceitavel tbm
        }
    }
}