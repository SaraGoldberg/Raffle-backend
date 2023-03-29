using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrdersDTO>();
        }
    }
}