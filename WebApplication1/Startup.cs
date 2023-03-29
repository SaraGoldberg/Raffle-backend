using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        ILogger<Startup> _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
            _logger.LogInformation("\nApllication up\n");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();

            services.AddScoped<ICatagoryDL, CatagoryDL>();
            services.AddScoped<ICatagoryBL, CatagoryBL>();

            services.AddScoped<IProductDL, ProductDL>();
            services.AddScoped<IProductBL, ProductBL>();

            services.AddScoped<IOrderDL, OrderDL>();
            services.AddScoped<IOrderBL, OrderBL>();

            services.AddScoped<IRatingDL, RatingDL>();
            services.AddScoped<IRatingBL, RatingBL>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddDbContext<Api_dataBaseContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("Restaurant")),ServiceLifetime.Scoped);
            services.AddSwaggerGen (c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseErrorMiddleware();
            app.UseStaticFiles();
            app.UseRouting();

            app.Map("/api",
                app1 =>
                { 
                    app1.UseRouting();
                    app1.UseInfoMiddleware();
                    app1.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }
    }
}