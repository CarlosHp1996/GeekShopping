using GeekShopping.Web.Data.Dtos;
using GeekShopping.Web.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var product = await _repository.Create(productDto);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _repository.GetAll();            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(long id)
        {
            var product =  await _repository.GetById(id);

            if (product.Id <= 0)
                return NotFound();
            return Ok(product);            
        }       
        
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] ProductDto productDto)
        {          
            if (productDto == null)
                return BadRequest();

            var product = await _repository.Update(productDto);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if(!status)
                return BadRequest();   
            return Ok(status);
        }
    }
}
