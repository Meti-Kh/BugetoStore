using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;

namespace Bugeto_Store.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execute(long? ParentId);
    }

    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDatabaseContext _context;

        public GetCategoriesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(long? ParentId)
        {
            var categories = _context.Categories
               .Include(p => p.ParentCategory)
               .Include(p => p.SubCategories)
               .Where(p => p.ParentCategoryId == ParentId)
               .ToList()
               .Select(p => new CategoriesDto
               {
                   ID = p.ID,
                   CategoryName = p.CategoryName,
                   Parent = p.ParentCategory != null ? new
                   ParentCategoryDto
                   {
                       ID = p.ParentCategory.ID,
                       CategoryName = p.ParentCategory.CategoryName,
                   }
                   : null,
                   HasChild = p.SubCategories.Count() > 0 ? true : false,
               }).ToList();


            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };

        }
    }
    public class CategoriesDto
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }

    }
    public class ParentCategoryDto
    {
        public long ID { get; set; }
        public string CategoryName { get; set; }
    }
}



