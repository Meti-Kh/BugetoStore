using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Fience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Pay.Command.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<RequestPayDto> Execute(long? userID, double amount);
    }

    public class AddRequestPayService : IAddRequestPayService
    {
        IDatabaseContext _context;
        public AddRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<RequestPayDto> Execute(long? userID, double amount)
        {
            var user = _context.Users.Find(userID);
            RequestPay requestPay = new RequestPay
            {
                Amount = amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user
            };
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();
            return new ResultDto<RequestPayDto>
            {
                Data = new RequestPayDto
                {
                    Authority = requestPay.Authority,
                    RefID = requestPay.RefID,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    Guid = requestPay.Guid,
                    RequestPayID = requestPay.ID
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class RequestPayDto
    {
        public Guid Guid { get; set; }
        public double Amount { get; set; }
        public long RequestPayID { get; set; }
        public string Email { get; set; }
        public string Authority { get; set; }
        public long RefID { get; set; }
    }
}
