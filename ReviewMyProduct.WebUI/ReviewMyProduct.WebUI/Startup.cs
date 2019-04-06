using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Review.Data.Context;
using Review.Data.Implementation.EFCore;
using Review.Data.Implementation.Mock;
using Review.Data.Interfaces;
using Review.Domain.Models;
using Review.Service.Services;

namespace ReviewMyProduct.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            // Repository Layer
            GetDependencyResolvedForEFCoreRepositoryLayer(services);


            // Service Layer
            GetDependencyResolvedForServiceLayer(services);

            services.AddDbContext<ReviewDbContext>();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ReviewDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.AccessDeniedPath = "/Account/Unauthorized";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseAuthentication();    // make use of identity

            app.UseMvcWithDefaultRoute();
        }

        private void GetDependencyResolvedForMockRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<ICommentRepository, MockCommentRepository>();
            services.AddScoped<IProductRepository, MockProductRepository>();
            services.AddScoped<IRatingRepository, MockRatingRepository>();

        }

        private void GetDependencyResolvedForEFCoreRepositoryLayer(IServiceCollection services)
        {
            services.AddScoped<ICommentRepository, EFCoreCommentRepository>();
            services.AddScoped<IProductRepository, EFCoreProductRepository>();
            services.AddScoped<IRatingRepository, EFCoreRatingRepository>();
        }

        private void GetDependencyResolvedForServiceLayer(IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRatingService, RatingService>();
        }
    }
}
