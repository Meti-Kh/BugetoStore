using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<ProductDetailForSiteDto> Execute(long productID);
    }


    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        IDatabaseContext _context;
        public GetProductDetailForSiteService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForSiteDto> Execute(long productID)
        {
            var product = _context.Products.Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages).Include(p => p.ProductFeatures)
                .Where(p => p.ID == productID).FirstOrDefault();
            if (product==null)
            {
                throw new Exception("Not found");
            }
            product.ViewCount++;
            _context.SaveChanges();
            return new ResultDto<ProductDetailForSiteDto>()
            {
                Data = new ProductDetailForSiteDto()
                {
                    ID = product.ID,
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory.CategoryName}--{product.Category.CategoryName}",
                    Description = product.Description,
                    Inventory = product.Invertory,
                    Price = product.Price,
                    Title = product.Name,
                    Features = product.ProductFeatures.Select(p => new ProductDetailForSite_FeatureDto()
                    { DisPlayName = p.DisPlayName
                      , Value = p.Value }).ToList(),
                    Images = product.ProductImages.Select(p => p.Src).ToList()
                },
                IsSuccess=true
            };

        }
    }

    public class ProductDetailForSiteDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailForSite_FeatureDto> Features { get; set; }
    }


    public class ProductDetailForSite_FeatureDto
    {
        public string DisPlayName { get; set; }
        public string Value { get; set; }

    }

}
