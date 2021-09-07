using MyStore.Application.Services.Common.GetHomePageImages;
using MyStore.Application.Services.HomePage.GetSliders;
using MyStore.Application.Services.Products.Queries.GetProductsForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public List<GetSlidersDto> GetSliders { get; set; }
        public List<GetHomePageImagesDto> GetHomePageImages { get; set; }
        public List<GetProductsForSiteDto> GetMobiles { get; set; }
    }
}
