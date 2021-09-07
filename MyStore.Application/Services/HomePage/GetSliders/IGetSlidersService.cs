using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.HomePage.GetSliders
{
  public  interface IGetSlidersService
    {
        ResultDto<List<GetSlidersDto>> Execute();
    }

    public class GetSlidersService : IGetSlidersService
    {
        IDatabaseContext _context;
        public GetSlidersService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetSlidersDto>> Execute()
        {
            var Sliders = _context.Sliders.OrderByDescending(d => d.ID).ToList().Select(
                p => new GetSlidersDto
                {
                    Link = p.Link,
                    Src = p.ImageSrc
                }
                ).ToList();
            return new ResultDto<List<GetSlidersDto>> {
            Data=Sliders, 
            IsSuccess=true
            };
        }
    }



    public class GetSlidersDto
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
