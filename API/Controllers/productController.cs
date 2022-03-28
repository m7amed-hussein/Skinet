using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class productController : ControllerBase
    {
        private readonly StoreContex _storeContex;
        public productController(StoreContex storeContex)
        {
            _storeContex = storeContex;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            return await _storeContex.Products.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _storeContex.Products.FindAsync(id);
            return  product== null ? BadRequest("No product with this id") : product; 
        }
    }
}