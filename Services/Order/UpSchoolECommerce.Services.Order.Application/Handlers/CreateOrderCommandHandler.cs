using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Order.Application.Commands;
using UpSchoolECommerce.Services.Order.Application.DTOs;
using UpSchoolECommerce.Services.Order.Domain.OrderAggregate;
using UpSchoolECommerce.Services.Order.Infrastructure;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseDTO<CreatedOrderDTO>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<ResponseDTO<CreatedOrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAdress = new Adress(request.Adress.City, request.Adress.District, request.Adress.Street, request.Adress.ZipCode);
            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAdress);
            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });
            await _orderDbContext.Orders.AddAsync(newOrder);
            await _orderDbContext.SaveChangesAsync();
            return ResponseDTO<CreatedOrderDTO>.Success(new CreatedOrderDTO { OrderId = newOrder.Id },204);
        }
    }
}
