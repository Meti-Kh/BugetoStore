using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Pay.Query.GetRequestPayService
{
   public interface IGetRequestPayService
    {
        ResultDto<RequestPayDto> Execute(Guid guid);
    }

    public class GetOrdersService : IGetRequestPayService
    {
        IDatabaseContext _context;
        public GetOrdersService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<RequestPayDto> Execute(Guid guid)
        {
            var requestPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();
            return new ResultDto<RequestPayDto>
            {
                Data = new RequestPayDto {Amount=requestPay.Amount ,
                RequestPayID=requestPay.ID}
               ,IsSuccess=true
            };
        }
    }

    public class RequestPayDto
    {
        public long RequestPayID { get; set; }
        public double Amount { get; set; }

    }
}
