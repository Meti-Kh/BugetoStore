using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Common.IGetMenuService
{
    public interface IGetMenuItemService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }

    public class GetMenuIteamService : IGetMenuItemService
    {
        IDatabaseContext _context;
        public GetMenuIteamService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var Categories = _context.Categories.Include(p => p.SubCategories)
                 .Where(p => p.ParentCategoryId == null).ToList()
                 .Select(p=>new MenuItemDto {
                 CatID=p.ID,
                 Name=p.CategoryName,
                     Childs = p.SubCategories.ToList().Select(child => new MenuItemDto
                     {
                         CatID = child.ID,
                         Name = child.CategoryName,
                     }).ToList(),
                 }).ToList();
            return new ResultDto<List<MenuItemDto>>()
            {
                Data = Categories,
                IsSuccess = true,

            };

        }
    }

    public class MenuItemDto
    {
        public long CatID { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Childs { get; set; }

    }
}
