using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Common.GetHomePageImages
{
   public interface IGetHomePageImagesService
    {
        ResultDto<List<GetHomePageImagesDto>> Execute();
    }

    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        IDatabaseContext _context;
        public GetHomePageImagesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetHomePageImagesDto>> Execute()
        {
            var Images = _context.HomePageImages.OrderByDescending(p => p.ID).Select(p => new GetHomePageImagesDto
            {
                ID = p.ID,
                Src = p.Src,
                Link = p.Src,
                ImageLocation = p.PageLocation
            }
            ).ToList();
            return new ResultDto<List<GetHomePageImagesDto>> 
            {
                Data=Images,
                IsSuccess=true
            };
        }
    }

    public class GetHomePageImagesDto
    {
        public long ID { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public HomePageLocation ImageLocation { get; set; }
    }

}
