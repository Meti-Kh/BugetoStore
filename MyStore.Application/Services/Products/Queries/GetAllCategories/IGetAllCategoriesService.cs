using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Bugeto_Store.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }


    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDatabaseContext _context;

        public GetAllCategoriesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null&&p.ParentCategory.IsRemoved==false)
                .Select(p => new AllCategoriesDto
                {
                    ID = p.ID,
                    Name = $"{p.ParentCategory.CategoryName} - {p.CategoryName}",
                }
                ).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }

    public class AllCategoriesDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }



}
