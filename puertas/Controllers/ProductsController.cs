using Microsoft.AspNetCore.Mvc;
using puertas.Repositories;
using puertas.Models;
using puertas.Dtos;

namespace puertas.Controllers
{   
    [ApiController]
    [Route("products")]
    //[Route("[controller]")]
    public class ProductsController : ControllerBase{
        private readonly IProductsRepository repository;

        public ProductsController(IProductsRepository repository){
            this.repository = repository;
        }

        //GET /products
        [HttpGet]
        public IEnumerable<ProductDto> GetProducts(){
            var products = repository.GetProducts().Select(product => product.AsDto());
            return products;
        }

        //GET /product/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(Guid id){
            //ActionResult permite retornar o objeto encontrado ou o status
            var product = repository.GetProduct(id);
            if (product is null){
                return NotFound();
            }
            return Ok(product.AsDto());
            //return product; aceitavel tbm
        }
    }
}