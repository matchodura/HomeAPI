using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.HubConfig;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Repositories;
using HomeAPI.Services;
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
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace HomeAPI
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


            //services.AddCors(policy =>
            //{
            //    policy.AddPolicy("CorsPolicy", opt => opt
            //        .AllowAnyOrigin()
            //        .AllowAnyHeader()
            //        .AllowAnyMethod());
            //});

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //                      builder =>
            //                      {
            //                          builder.AllowAnyHeader();
            //                          builder.AllowAnyMethod();
            //                          builder.AllowAnyOrigin();
            //                      });
            //});

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder
                 .WithOrigins("http://localhost:4200/")
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });

            //services.AddDbContext<HomeContext>(options => options
            //    .UseMySql("Server=192.168.1.181; Port=3306; Database=homeapi; User=test2;Password=test;",
            //        mysqlOptions =>
            //            mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 3, 27), ServerType.MariaDb))

            //            )
            //    );

            services.AddDbContext<HomeContext>(options => options
                 //.UseMySQL("Server=192.168.1.181; Port=3306; Database=homeapi; User=api;Password=api;SSL Mode=None;")
                 .UseMySQL("Server=192.168.1.181; Port=3306; Database=homeapi; User=test2;Password=test;SSL Mode=None;")
                 .EnableSensitiveDataLogging()
                );
          

            services.AddSignalR();


            services.AddControllersWithViews().AddNewtonsoftJson();
          
            services.AddRazorPages();
                  
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IMotionSensorRepository, MotionSensorRepository>();
            services.AddScoped<IBoxRepository, BoxRepository>();
            services.AddScoped<IDHTRepository, DHTRepository>();         
            services.AddScoped<ILightSensorRepository, LightSensorRepository>();
            services.AddSingleton<SensorDataLogging>();

           // services.AddHostedService<BoxService>();

            // Register the Swagger services
            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();         
            }

            app.UseHttpsRedirection();
          
            app.UseRouting();
            app.UseCors("CorsPolicy");
          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChartHub>("/chart");
                endpoints.MapHub<MotionHub>("/notify");          
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
