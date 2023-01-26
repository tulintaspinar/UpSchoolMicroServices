using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Order.Application.DTOs;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<ResponseDTO<CreatedOrderDTO>>
    {
        public string BuyerId { get; set; }
        public AdressDTO Adress { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
