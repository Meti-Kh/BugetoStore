using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Services.HomePage.AddNewHomePageImage;
using MyStore.Domain.Entities.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class HomePageController : Controller
    {
        private readonly IAddNewHomePageImagesService _addNewHomePageImagesService;
        public HomePageController(IAddNewHomePageImagesService addNewHomePageImagesService)
        {
            _addNewHomePageImagesService = addNewHomePageImagesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string link, IFormFile file,HomePageLocation imageLocation)
        {
            _addNewHomePageImagesService.Execute(
                new RequestAddNewHomePageImageDto {
                file=file,
                Link=link,
                PageLocation=imageLocation
                }
                );
            return View();
        }
    }
}
