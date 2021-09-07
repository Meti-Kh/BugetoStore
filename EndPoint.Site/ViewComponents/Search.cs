using MyStore.Application.Services.Common.GetCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        IGetCategoriesService _getCategoriesService;
        public Search(IGetCategoriesService getCategoriesService)
        {
            _getCategoriesService = getCategoriesService;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search",model: _getCategoriesService.Execute().Data);
        }


    }
}
