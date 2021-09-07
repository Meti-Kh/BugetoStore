using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using MyStore.Application.Services.Products.Commands.EditCategory;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class CategoryController : Controller
    {
        private IProductFacad _productFacad;

        public CategoryController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }
        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(long? parentId,string Name)
        {
            return Json(_productFacad.AddNewCategoryService.Execute(parentId,Name));
        }
        [HttpPost]
        public IActionResult EditCategory(long categoryId,string categoryName)
        {
            return Json(_productFacad.EditCategoryService.Execute(new RequestEditCategoryDto() {CategoryID=categoryId,Name=categoryName }));
        }
        [HttpPost]
        public IActionResult Delete(long categoryId)
        {
            return Json(_productFacad.RemoveCategoryService.Execute(categoryId));
        }
    }
}
