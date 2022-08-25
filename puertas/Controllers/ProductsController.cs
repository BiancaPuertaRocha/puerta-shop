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

        //POST /product
        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(CreateProductDto productDto){
            Product product = new(){
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };
            repository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id}, product.AsDto());
        }

        //DELETE /product/{id}
        [HttpDelete]
        public ActionResult DeleteProcuct(Guid id){
            if(repository.DeleteProduct(id)){
                return Ok();
            }
            else{
              return NotFound("product not found");  
            }
        }

        //PUT /product/{id}
        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(Guid id, UpdateProductDto productDto){
            //ActionResult permite retornar o objeto encontrado ou o status
            var product = repository.GetProduct(id);
            if (product is null){
                return NotFound();
            }
            Product updateProduct = product with {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };
            repository.UpdateProduct(updateProduct);
            return Ok();
            //return product; aceitavel tbm
        }
    }
}