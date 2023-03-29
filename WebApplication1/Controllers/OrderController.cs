using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBL _orderBL;
        IMapper _mapper;
        public OrderController(IOrderBL order, IMapper mapper)
        {
            _orderBL = order;
            _mapper = mapper;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrdersDTO>>> Get(int id)
        {
            List<Order> orders = await _orderBL.getOrder(id);
            //convert to Dto
            if (orders == null)
                return NoContent();
            List<OrdersDTO> ordersDTOs =  _mapper.Map<List<Order>, List<OrdersDTO>>(orders);
            return Ok(ordersDTOs);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post(Order order)
        {
            return await _orderBL.postOrder(order);
        }
    }
}