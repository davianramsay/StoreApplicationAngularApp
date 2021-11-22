using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StoreApplicationAngularAppStorage.Repository;
using StoreApplicationAngularAppStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApplicationAngularAppStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApplicationAngularApp
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

            services.AddScoped<ICustomerRepo, CustomerRepository>();
            services.AddScoped<IStoreRepo, StoreRepository>();

            services.AddCors((options) =>
            {
                options.AddPolicy(name: "dev", builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:4200",
                        "https://localhost:5001",
                        "https://localhost:44348",
                        "https://localhost:44338",
                        "http://localhost:5000"
                        )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreApplicationAngularApp", Version = "v1" });
            });



            services.AddDbContext<StoreApplicationAngularAppContext>(options => {
                //if db options is already configured, dont do anything otherwise use the connection string I have in secrets.json
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SAWADB"));
                }
            });//end addition here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreApplicationAngularApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("dev");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
