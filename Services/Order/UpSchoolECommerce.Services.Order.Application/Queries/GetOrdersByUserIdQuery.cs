using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Order.Application.DTOs;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<ResponseDTO<List<OrderDTO>>>
    {
        public string UserId { get; set; }
    }
}
