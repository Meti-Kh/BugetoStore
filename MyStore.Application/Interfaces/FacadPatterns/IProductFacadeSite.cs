using MyStore.Application.Services.Products.Queries.GetProductDetailForSite;
using MyStore.Application.Services.Products.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Interfaces.FacadPatterns
{
   public interface IProductFacadeSite
    {
        IGetProductForSiteSetvice GetProductForSiteSetvice { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
