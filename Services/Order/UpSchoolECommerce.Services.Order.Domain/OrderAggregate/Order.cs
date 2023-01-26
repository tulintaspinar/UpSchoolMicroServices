using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Services.Order.DomainCore;

namespace UpSchoolECommerce.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity,IAggregateRoot
    {
        public DateTime CreatedDate { get; set; }
        public Adress Adress { get; set; }
        public string BuyerId { get; set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {

        }
        public Order(string buyerId,Adress adress)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId= buyerId;
            Adress = adress;
        }
        public void AddOrderItem(string productId,string productName,decimal price,string pictureUrl)
        {
            var existProduct = _orderItems.Any(x=>x.ProductId==productId);
            if(!existProduct)
            {
                var neworderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(neworderItem);
            }
        }

        public decimal GetTotalPrice=>_orderItems.Sum(x=>x.Price);
    }
}
