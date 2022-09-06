using Microsoft.AspNetCore.Identity;
using VFT.CMS.Application.Categories;
using VFT.CMS.Application.Menus;
using VFT.CMS.Application.PostsNews;
using VFT.CMS.Application.Services;
using VFT.CMS.EntityFrameworkCore;

namespace VFT.CMS.Web.Areas.Admin.Common
{
    public static class GlobalHelper
    {
        public static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryService));
            services.AddAutoMapper(typeof(MenuService));
            services.AddAutoMapper(typeof(PostsService));
        }
        public static void RegisterServiceLifetimer(IServiceCollection services)
        {
            //Scoped services
            services.AddScoped<SignInManager<CMSIdentityUser>, SignInManager<CMSIdentityUser>>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPostsService, PostsService>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

        }
    }
}
