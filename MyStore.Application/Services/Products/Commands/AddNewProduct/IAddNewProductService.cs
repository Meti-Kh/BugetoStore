using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using MyStore.Domain.Entities;
using Microsoft.Extensions.Hosting;
using MyStore.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }


    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDatabaseContext _context;
        private  IHostingEnvironment env;

        public AddNewProductService(IDatabaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            env = hostingEnvironment;
        }


        public ResultDto Execute(RequestAddNewProductDto request)
        {

            try
            {

                var category = _context.Categories.Find(request.CategoryId);

                MyStore.Domain.Entities.Products.Products product = new MyStore.Domain.Entities.Products.Products()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    Invertory = request.Inventory,
                    Category = category,
                    DisPlayed= request.Displayed,
                };
                _context.Products.Add(product);

                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    productImages.Add(new ProductImage
                    {
                        Product = product,
                        Src = uploadedResult.FileNameAddress,
                    });
                }

                _context.ProductImages.AddRange(productImages);


                List<ProductFeatures> productFeatures = new List<ProductFeatures>();
                foreach (var item in request.Features)
                {
                    productFeatures.Add(new ProductFeatures
                    {
                        DisPlayName = item.DisplayName,
                        Value = item.Value,
                        Product= product,
                    });
                }
                _context.ProductFeatures.AddRange(productFeatures);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                };
            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }

        }



        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(env.ContentRootPath, folder);
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
    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
    public class RequestAddNewProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }

        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Features> Features { get; set; }
    }

    public class AddNewProduct_Features
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
