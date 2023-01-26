using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Order.Application.DTOs;

namespace UpSchoolECommerce.Services.Order.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.OrderItem,OrderItemDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.Adress,AdressDTO>().ReverseMap();
        }
    }
}
