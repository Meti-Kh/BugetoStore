using Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
   [Area("Admin")]
  //  [Authorize(Roles = "Admin,Operator")]
    public class ProductsController : Controller
    {
        IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad =  productFacad;
        }
        public IActionResult Index(int page=1,int pageSize=20)
        {
            return View(_productFacad.GetProductForAdminService.Execute().Data);
        }

        public IActionResult Detail(long ID)
        {
            return View(_productFacad.GetProductDetailForAdminService.Execute(ID).Data);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "ID", "Name");
            return View();                                                                           
        }
        [HttpPost]
        public IActionResult AddProduct(RequestAddNewProductDto request,List<AddNewProduct_Features> features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = features;
            return Json(_productFacad.AddNewProductService.Execute(request));
        }

      
    }
}
