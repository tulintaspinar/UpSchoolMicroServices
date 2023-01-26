using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Order.Application.DTOs;
using UpSchoolECommerce.Services.Order.Application.Queries;
using UpSchoolECommerce.Services.Order.Infrastructure;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, ResponseDTO<List<OrderDTO>>>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<List<OrderDTO>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();
            return ResponseDTO<List<OrderDTO>>.Success(_mapper.Map<List<OrderDTO>>(orders), 200);
            //mapleme yazılacak
        }
    }
}
