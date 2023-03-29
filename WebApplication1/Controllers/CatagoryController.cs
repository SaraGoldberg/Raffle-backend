using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        ICatagoryBL _catagoryBl;
        public CatagoryController(ICatagoryBL catagory)
        {
            _catagoryBl = catagory;
        }

        // GET: api/<CatagoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> category = await _catagoryBl.getCatagory();
            if (category == null)
                return NoContent();
            return Ok(category);
        }

        // GET api/<CatagoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Category>>> Get(int id)
        {
            List<Category> category = await _catagoryBl.getCatagory(id);
            if (category == null)
                return NoContent();
            return Ok(category);
        }
    }
}
