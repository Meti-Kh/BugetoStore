using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Products.Commands.EditCategory
{
    public interface IEditCategoryService
    {
        ResultDto Execute(RequestEditCategoryDto request);
    }
    public class EditCategoryService : IEditCategoryService
    {
        private IDatabaseContext _context;
        public EditCategoryService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditCategoryDto request)
        {
            var category = _context.Categories.Find(request.CategoryID);
            if (category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }

            category.CategoryName = request.Name;
            _context.SaveChanges();
            return new ResultDto (){ IsSuccess=true,Message="عملیات موفقیت آمیز بود"};
        }
    }

    public class RequestEditCategoryDto
    {
        public long CategoryID { get; set; }
        public string Name { get; set; }

    }
}
