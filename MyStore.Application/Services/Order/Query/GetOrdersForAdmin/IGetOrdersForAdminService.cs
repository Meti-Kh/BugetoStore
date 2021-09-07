using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Order.Query.GetOrdersForAdmin
{
  public  interface IGetOrdersForAdminService
    {
        ResultDto<List<GetOrdersForAdminDto>> Execute(OrderState orderState);
    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        IDatabaseContext _context;
        public GetOrdersForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetOrdersForAdminDto>> Execute(OrderState orderState)
        {
            var Orders = _context.Orders.Include(p => p.OrderDetails).Where(p => p.OrderState == orderState).OrderByDescending(p => p.ID).ToList().Select(p => new GetOrdersForAdminDto
            {
                UserId = p.UserID,
                OrderId = p.ID,
                InsetTime = p.InsertTime,
                OrderState = p.OrderState,
                ProductCount = p.OrderDetails.Count,
                RequestId = p.RequestPayID
            }
            ).ToList();

            return new ResultDto<List<GetOrdersForAdminDto>> 
            {
            Data=Orders,
            IsSuccess=true
            };
        }
    }

    public class GetOrdersForAdminDto
    {
        public long OrderId { get; set; }
        public DateTime InsetTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }

    }

}
