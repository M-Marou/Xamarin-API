using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetBooks(int id)
        {
            return await _productRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product Product)
        {
            var newProduct = await _productRepository.Create(Product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }
        [HttpPut]
        public async Task<ActionResult> PutProducts(int id, [FromBody] Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            await _productRepository.Update(Product);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _productRepository.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _productRepository.Delete(bookToDelete.Id);
            return NoContent();
        }

    }
}
