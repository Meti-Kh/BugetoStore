using Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.Commands.AddNewCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetAllCategories;
using Bugeto_Store.Application.Services.Products.Queries.GetCategories;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Microsoft.Extensions.Hosting;
using MyStore.Application.Interfaces.Context;
using MyStore.Application.Services.Products.Commands.EditCategory;
using MyStore.Application.Services.Products.Commands.RemoveCategory;

namespace Bugeto_Store.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        private IHostingEnvironment _environment;
        public ProductFacad(IDatabaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }


        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);
            }
        }
        private IEditCategoryService _editCategoryService;
        public IEditCategoryService EditCategoryService
        {
            get
            {
                return _editCategoryService = _editCategoryService ?? new EditCategoryService(_context);
            }
        }

        private IRemoveCategoryService _removeCategoryService;
        public IRemoveCategoryService RemoveCategoryService
        {
            get
            {
                return _removeCategoryService = _removeCategoryService ?? new RemoveCategoryService(_context);
            }
        }

        private IAddNewProductService _addNewProductService;
        public IAddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_context,_environment);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }
    }
}
