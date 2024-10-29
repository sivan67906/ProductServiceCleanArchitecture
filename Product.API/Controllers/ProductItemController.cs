using Microsoft.AspNetCore.Mvc;
using Product.Application.Services;
using Product.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductItemServices _productItemServices;

        public ProductItemController(IProductItemServices ProductItemServices)
        {
            _productItemServices = ProductItemServices;
        }

        // GET: api/<ProductItemController>
        [HttpGet]
        public async Task<List<ProductItem>> Get()
        {
            return await _productItemServices.GetAllProductItems();
        }

        [HttpGet("{id}")]
        public async Task<ProductItem> Get(int id)
        {
            return await _productItemServices.GetProductItemById(id);
        }

        [HttpPost]
        public async Task<ProductItem> Post([FromBody] ProductItem productItem)
        {
            return await _productItemServices.CreateProductItem(productItem);
        }

        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] ProductItem productItem)
        {
            return await _productItemServices.UpdateProductItem(id, productItem);
        }
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _productItemServices.DeleteProductItem(id);
        }
    }
}
