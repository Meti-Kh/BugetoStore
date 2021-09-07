using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Pay.Query.GetRequestPayForAdmin
{
    public interface IGetRequestPayForAdminService
    {
        ResultDto<List<RequestPayDto>> Execute();
    }

    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {
        IDatabaseContext _context;
        public GetRequestPayForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RequestPayDto>> Execute()
        {
            var Pays = _context.RequestPays.Include(p => p.User).ToList().Select(p => new RequestPayDto
            {
                Amount = p.Amount,
                Authority = p.Authority,
                Guid = p.Guid,
                ID = p.ID,
                IsPay = p.IsPay,
                PayDateTime = p.PayDateTime,
                RefID = p.RefID,
                UserID = p.UserID,
                UserName = p.User.FullName
            }).ToList();

            return new ResultDto<List<RequestPayDto>> {
            Data=Pays, IsSuccess=true
            };
        }
    }


    public class RequestPayDto
    {
        public long ID { get; set; }
        public Guid Guid { get; set; }
        public double Amount { get; set; }
        public string UserName { get; set; }
        public long UserID { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDateTime { get; set; }
        public string Authority { get; set; }
        public long RefID { get; set; }
    }

}
