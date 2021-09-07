using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common;
using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Products.Queries.GetProductsForSite
{
   public interface IGetProductForSiteSetvice
    {
        ResultDto<ResultGetProductsForSiteDto> Execute(Ordering ordering,int page,long? CatID,string SearchKey,int pageSize);
    }
    public enum Ordering
    {
        NotOrder = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروشترین
        /// </summary>
        Bestselling = 2,
        /// <summary>
        /// محبوبترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        /// جدیدترین
        /// </summary>
        theNewest = 4,
        /// <summary>
        /// ارزانترین
        /// </summary>
        Cheapest = 5,
        /// <summary>
        /// گرانترین
        /// </summary>
        theMostExpensive = 6
    }

    public class GetProductForSiteSetvice : IGetProductForSiteSetvice
    {
        private IDatabaseContext _context;
        public GetProductForSiteSetvice(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultGetProductsForSiteDto> Execute(Ordering ordering,int page,long? CatID,string SearchKey,int PageSize)
        {
            int totalRow = 0;
            var productQuery = _context.Products
                .Include(p => p.ProductImages).AsQueryable();
            if (CatID!=null)
            {
                productQuery = productQuery.Where(p=>p.CategoryID==CatID||p.Category.ParentCategoryId==CatID).AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {

                productQuery = productQuery.Where(p => p.Brand.ToLower().Contains(SearchKey)  || p.Name.ToLower().Contains(SearchKey) ).AsQueryable();
            }
            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQuery = productQuery.OrderBy(p=>p.ID).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    break;
                case Ordering.MostPopular:
                    break;
                case Ordering.theNewest:
                    productQuery = productQuery.OrderByDescending(p => p.ID).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    productQuery = productQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                default:
                    break;
            }
            var  Products=productQuery.ToPaged(page,PageSize,  out totalRow);

            Random rnd = new Random();
            return new ResultDto<ResultGetProductsForSiteDto>() {
                Data = new ResultGetProductsForSiteDto { TotalRow = totalRow,
                    Products = (List<GetProductsForSiteDto>)Products.Select(p => new GetProductsForSiteDto {
                        ID = p.ID,
                        Title = p.Name
                     , Star = rnd.Next(1, 5)
                     , Price = p.Price
                     , ImageSrc = p.ProductImages.FirstOrDefault().Src }).ToList()
            }
            };
        }
    }


    public class GetProductsForSiteDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageSrc { get; set; }
        public int Star { get; set; }
    }
    public class ResultGetProductsForSiteDto
    {
        public List<GetProductsForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }

}
