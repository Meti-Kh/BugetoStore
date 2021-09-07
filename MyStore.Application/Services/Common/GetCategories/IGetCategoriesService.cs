using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Common.GetCategories
{
  public  interface IGetCategoriesService
    {
        ResultDto<List<GetCategoriesDto>> Execute();
    }

    public class GetCategoriesService : IGetCategoriesService
    {
        IDatabaseContext _context;
        public GetCategoriesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetCategoriesDto>> Execute()
        {
            var Categories = _context.Categories.Where(c => c.ParentCategoryId == null).Select(c=>new GetCategoriesDto
            {
                CatID=c.ID,
                Name=c.CategoryName
            }
            ).ToList();

            return new ResultDto<List<GetCategoriesDto>>
            {
                Data = Categories,
                IsSuccess = true
            }; 
        }
    }

    public class GetCategoriesDto
    {
        public long CatID { get; set; }
        public string Name { get; set; }
    }
}
