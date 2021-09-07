using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Products.Commands.RemoveCategory
{
   public interface IRemoveCategoryService
    {
        ResultDto Execute(long CategoryID);
    }

    public class RemoveCategoryService : IRemoveCategoryService
    {
        private IDatabaseContext _context;
        public RemoveCategoryService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long CategoryID)
        {
            var category = _context.Categories.Find(CategoryID);
            if (category == null)
            {
                return new ResultDto() {IsSuccess=false,Message="عملیات حذف انجام نشد" };
            }
            category.IsRemoved = true;
            category.RemovedTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto() { IsSuccess=true,Message="حذف انحام شد"};
        }
    }
}
