using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DL;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBL _productBL;

        public ProductController(IProductBL product)
        {
            _productBL = product;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> products = await _productBL.getProduct();
            if (products == null)
                return NoContent();
            return Ok(products);
        }

        // GET api/<CatagoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> Get(int id)
        {
            List<Product> product = await _productBL.getProduct(id);
            if (product == null)
                return NoContent();
            return Ok(product);
        }
    }
}
