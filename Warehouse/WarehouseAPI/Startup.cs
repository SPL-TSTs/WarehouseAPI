using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Warehouse.Business.Helpers;
using Warehouse.Business.Mapper;
using Warehouse.Business.Services;
using Warehouse.Data.Contexts;
using Warehouse.Data.Repositories;

namespace WarehouseAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DeviceMapper));
            services.AddSingleton(provider => new DbContext(Configuration));
            services.AddTransient<IElectricMeterRepository, ElectricMeterRepository>();
            services.AddTransient<IWaterMeterRepository, WaterMeterRepository>();
            services.AddTransient<IGatewayRepository, GatewayRepository>();
            services.AddTransient<IWaterMeterService, WaterMeterService>();
            services.AddTransient<IGatewayService, GatewayService>();
            services.AddTransient<IElectricMeterService, ElectricMeterService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "default",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyOrigin();
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Demo",
                    Version = "v1",
                    Description = "A simple API to store devices in Azure Table Storage",
                    Contact = new OpenApiContact
                    {
                        Email = "sebastian-dot-pedrazalopez@yahoo.com",
                        Name = "SPL",
                        Url = new Uri("https://demo.com/")
                    }
                });
                opt.SchemaFilter<SwaggerPropertyFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
