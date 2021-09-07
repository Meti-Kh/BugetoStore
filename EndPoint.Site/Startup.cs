using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyStore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.FacadPattern;
using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using Bugeto_Store.Application.Services.Users.Commands.RemoveUser;
using Bugeto_Store.Application.Services.Users.Commands.UserLogin;
using Bugeto_Store.Application.Services.Users.Commands.UserSatusChange;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Application.Services.Users.Command.CraeteUser;
using MyStore.Application.Services.Users.Query.GetUsers;
using GetRolesService = Bugeto_Store.Application.Services.Users.Queries.GetRoles.GetRolesService;
using MyStore.Application.Interfaces.FacadPatterns;
using MyStore.Application.Services.Products.FacedPattern;
using MyStore.Application.Services.Common.IGetMenuService;
using  MyStore.Application.Services.Common.GetCategories;
using MyStore.Application.Services.HomePage.AddNewSilder;
using MyStore.Application.Services.HomePage.GetSliders;
using MyStore.Application.Services.HomePage.AddNewHomePageImage;
using MyStore.Application.Services.Common.GetHomePageImages;
using MyStore.Application.Services.Cart;
using MyStore.Application.Services.Pay.Command.AddRequestPay;
using MyStore.Application.Services.Pay.Query.GetRequestPayService;
using MyStore.Application.Services.Order.Command.AddOrder;
using MyStore.Application.Services.Order.Query.GetOrders;
using MyStore.Common.Role;
using MyStore.Application.Services.Order.Query.GetOrdersForAdmin;
using MyStore.Application.Services.Pay.Query.GetRequestPayForAdmin;

namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. 212
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });



            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/signIn");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            });


            services.AddScoped<IDatabaseContext,DatabaseContext>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<ICreateUserService, CreateUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IEditUserService, EditUserService>();
            services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IGetMenuItemService,GetMenuIteamService>();
            services.AddScoped<IGetCategoriesService, GetCategoriesService>();
            services.AddScoped<IAddNewSliderService, AddNewSliderService>();
            services.AddScoped<IGetSlidersService, GetSlidersService>();
            services.AddScoped<IAddNewHomePageImagesService, AddNewHomePageImagesService>();
            services.AddScoped<IGetHomePageImagesService,GetHomePageImagesService>();
            services.AddScoped<ICartService,CartService>();
            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService,GetOrdersService>();
            services.AddScoped<IAddOrderService, AddOrderService>();
            services.AddScoped<IGetOrdersService, GetOrderService>();
            services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
            services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();
            //Facade Inject
            services.AddScoped<IProductFacad, ProductFacad>();
            services.AddScoped<IProductFacadeSite,ProductFacadeSite>();
          

            string ConnectionString = "Data Source=.;Initial Catalog=MyStoreDB;Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option=>option.UseSqlServer(ConnectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                   name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
