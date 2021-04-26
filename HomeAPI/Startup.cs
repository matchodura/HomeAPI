using HomeAPI.Data;
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
            // Poni¿sza konfiguracja jest bazowa i niezwykle prosta
            // AllowAnyOrigin() - mo¿e zostaæ zmienione na np. WithOrigings("http://www.naszezrodlo.com") - dostêp tylko z tego miejsca
            // AllowAnyMethod() - mo¿emy zezwoliæ na dostêp do wybranych metod np. WithMethods("POST", "GET")
            // AllowAnyHeader() - mo¿emy akceptowaæ jedynie wybrane nag³ówki, np. WithHeaders("accept", "content-type")
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddDbContext<HomeContext>(options => options
                .UseMySql("Server=localhost; Database=homeapi;User=homeapi;Password=homeapi;",
                    mysqlOptions =>
                        mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb))));

            services.AddControllersWithViews().AddNewtonsoftJson();
          
            services.AddRazorPages();


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
            });
        }
    }
}
