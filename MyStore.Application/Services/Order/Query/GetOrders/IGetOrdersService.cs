using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Order.Query.GetOrders
{
   public interface IGetOrdersService
    {
        ResultDto<List<GetUserOrdersDto>> Execute(long UserID);
    }

    public class GetOrderService : IGetOrdersService
    {
        IDatabaseContext _context;
        public GetOrderService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetUserOrdersDto>> Execute(long UserID)
        {
            var orders = _context.Orders.Include(p => p.OrderDetails).ThenInclude(p => p.Product).Where(p => p.UserID == UserID)
                 .OrderByDescending(p => p.ID).ToList().Select(p => new GetUserOrdersDto
                 {
                     OrderId = p.ID,
                     OrderState = p.OrderState,
                     RequestPayId = p.RequestPayID,
                     OrderDetails = p.OrderDetails.Select(o => new OrderDetailsDto
                     {
                         Count = o.Count,
                         OrderDetailId = o.ID,
                         Price = o.Price,
                         ProductId = o.ProductID,
                         ProductName = o.Product.Name
                     }).ToList()
                 }).ToList();

            return new ResultDto<List<GetUserOrdersDto>> 
            {
            Data=orders,
            IsSuccess=true
            };
        }
    }


    public class GetUserOrdersDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }
    public class OrderDetailsDto
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
