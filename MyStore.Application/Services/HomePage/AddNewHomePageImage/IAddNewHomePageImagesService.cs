using Application.Services.Products.Commands.AddNewProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.HomePage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.HomePage.AddNewHomePageImage
{
   public interface IAddNewHomePageImagesService
    {
        ResultDto Execute(RequestAddNewHomePageImageDto request);
    }

    public class AddNewHomePageImagesService : IAddNewHomePageImagesService
    {
        IDatabaseContext _context;
        IHostingEnvironment _environment;
        public AddNewHomePageImagesService(IDatabaseContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(RequestAddNewHomePageImageDto request)
        {
            var resultUpload = UploadFile(request.file);
            HomePageImages homePageImage = new HomePageImages() 
            {
                Link=request.Link,
                Src=resultUpload.FileNameAddress,
                PageLocation=request.PageLocation
            };
            _context.HomePageImages.Add(homePageImage);
            _context.SaveChanges();
            return new ResultDto 
            {IsSuccess=true };
           
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_environment.ContentRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class RequestAddNewHomePageImageDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public HomePageLocation PageLocation { get; set; }
    }
}
