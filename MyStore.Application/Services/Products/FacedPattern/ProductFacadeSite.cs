using MyStore.Application.Interfaces.Context;
using MyStore.Application.Interfaces.FacadPatterns;
using MyStore.Application.Services.Products.Queries.GetProductDetailForSite;
using MyStore.Application.Services.Products.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Products.FacedPattern
{
    public class ProductFacadeSite : IProductFacadeSite
    {
        private IDatabaseContext _context;
        public ProductFacadeSite(IDatabaseContext context)
        {
            _context = context;
        }

        private IGetProductForSiteSetvice _getProductForSiteSetvice;
        public IGetProductForSiteSetvice GetProductForSiteSetvice { get {
                if (_getProductForSiteSetvice==null)
                {
                    _getProductForSiteSetvice = new GetProductForSiteSetvice(_context);
                }
                return _getProductForSiteSetvice;
            } }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                if (_getProductDetailForSiteService == null)
                {
                    _getProductDetailForSiteService = new GetProductDetailForSiteService(_context);
                }
                return _getProductDetailForSiteService;
            }
        }
    }
}
