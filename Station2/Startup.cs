using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Station2.Models;
using Microsoft.EntityFrameworkCore;
//using Station2.Data;

namespace Station2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

                        services.AddDbContext<AppDbContext>(options =>
                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

                        services.AddDbContext<AppDbContext>(options =>
                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                        services.AddScoped<IItemMasterRepository, ItemRepository>();
                        services.AddScoped<IItemCategoryRepository, CategoryRepository>();
                        services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            //to create a scoped shopping cart using the GetCart method
            services.AddHttpContextAccessor();
            services.AddSession();
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
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            //to get the support of sessions  

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
