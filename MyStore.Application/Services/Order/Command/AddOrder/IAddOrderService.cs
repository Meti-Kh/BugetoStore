using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Order.Command.AddOrder
{
   public interface IAddOrderService
    {
        ResultDto Execute(RequestAddOrderDto request);
    }

    public class AddOrderService : IAddOrderService
    {
        IDatabaseContext _context;
        public AddOrderService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddOrderDto request)
        {
            var user = _context.Users.Find(request.UserID);

            var requestPay = _context.RequestPays.Find(request.RequestPayID);

            var cart = _context.Carts.Include(p => p.CartItams).
                ThenInclude(p => p.Product).Where(p => p.ID == request.CartID).FirstOrDefault();

            requestPay.IsPay = true;
            requestPay.PayDateTime = DateTime.Now;

            cart.Finished = true;

            MyStore.Domain.Entities.Order.Order order = new Domain.Entities.Order.Order()
            {
                Address = "",
                RequestPay = requestPay,
                User = user,
                OrderState=OrderState.Processing
            };
            _context.Orders.Add(order);
            List<MyStore.Domain.Entities.Order.OrderDetail> orderDetails = new List<Domain.Entities.Order.OrderDetail>();
            foreach (var item in cart.CartItams)
            {
                MyStore.Domain.Entities.Order.OrderDetail orderDetail = new Domain.Entities.Order.OrderDetail
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product
                };
                orderDetails.Add(orderDetail);
            }
            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();

            return new ResultDto { IsSuccess=true};
        }

    }




    public class RequestAddOrderDto
    {
        public long UserID { get; set; }
        public long CartID { get; set; }
        public long RequestPayID { get; set; }

    }


}
