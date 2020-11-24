using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Account.Api.Database;
using Account.Api.Database.Repositories;
using Account.Api.Infrastructure;
using Account.Api.Models.Validators;
using Account.Api.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Account.Api
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
            ConfigureFluentValidation(services);

            //Registers the Custom services
            RegisterServices(services);

            ConfigureDatabase(services);

            services.AddControllers();

            //SWagger configuration
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Account Service API",
                    Version = "v2",
                    Description = "Account service endpoint",
                });
            });

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
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Account Service"));
        }
        private void ConfigureFluentValidation(IServiceCollection services)
        {
            services.AddMvc().
               AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserRegistrationValidator>());

        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IRSAHelper, RSAHelper>();
        }
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Accountdb"), sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    //Configuring Connection Resiliency: 
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
                // Changing default behavior when client evaluation occurs to throw. 
                // Default in EFCore would be to log warning when client evaluation is done.
                // options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            });
        }
    }
}
