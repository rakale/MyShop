using Abc.Domain.Shop;
using Abc.Infra;
using Abc.Infra.Shop;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soft.Data;
using System;

namespace Soft {
    public class Startup {

        private static string connection => "DefaultConnection";

        public Startup(IConfiguration c) => Configuration = c;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            registerDbContexts(services);
            registerAuthentication(services);
            services.AddRazorPages();
            registerRepositories(services);
            //const string connection = "DefaultConnection";
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString(connection)));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddRazorPages();

            //services.AddDbContext<ShopDbContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString(connection)));
        }

        private static void registerRepositories(IServiceCollection s) {
            s.AddScoped<IBasketsRepository, BasketsRepository>();
            s.AddScoped<IBasketItemsRepository, BasketItemsRepository>();
            s.AddScoped<IBrandsRepository, BrandsRepository>();
            s.AddScoped<ICatalogsRepository, CatalogsRepository>();
            s.AddScoped<IOrdersRepository, OrdersRepository>();
            s.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            s.AddScoped<IProductsRepository, ProductsRepository>();
        }

        private void registerAuthentication(IServiceCollection s) {
            s.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        private void registerDbContexts(IServiceCollection s) {
            registerDbContext<ApplicationDbContext>(s);
            registerDbContext<ShopDbContext>(s);
        }

        protected virtual void registerDbContext<T>(IServiceCollection s) where T : DbContext {
            s.AddDbContext<T>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(connection)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });
        }
    }
}
