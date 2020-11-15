using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Api.Database;
using Catalog.Api.Database.Repositories;
using Catalog.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Api
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
            RegisteredServices(services);            
            services.AddControllers();

            //SWagger configuration
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Catalog Service API",
                    Version = "v2",
                    Description = "Catalog service endpoints",
                });
            });
        }

        private void RegisteredServices(IServiceCollection services)
        {             
            //Database settings
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            //Custom services
            services.AddScoped<DatabaseContext, DatabaseContext>();          
            services.AddScoped<ICategoryRepositoty, CategoryRepositoty>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IQueryService, QueryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Setup allowed domain to access the service
            string allowedDomains = Configuration.GetValue<string>("AppSettings:AllowedDomains");
            string[] crossDomains = allowedDomains.Split(",".ToCharArray());
            foreach (var domain in crossDomains)
            {
                app.UseCors(options =>
                options.WithOrigins(domain)
                .AllowAnyMethod()
                .AllowAnyHeader());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Swagger UI setup
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Catalog Service"));
        }
    }
}
