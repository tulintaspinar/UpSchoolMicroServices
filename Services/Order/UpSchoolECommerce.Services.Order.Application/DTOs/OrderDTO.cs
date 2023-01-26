using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchoolECommerce.Services.Order.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public AdressDTO Adress { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemDTO> OrderItemDTOs { get; set; }
    }
}
