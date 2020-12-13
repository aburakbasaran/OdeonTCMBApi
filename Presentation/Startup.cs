using Application;
using Application.Interfaces;
using Application.Services;
using Domain.Models.TCMB;
using Infrastructure;
using Infrastructure.Files;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presentation.DI.Middleware;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Presentation
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
            var tcmbServiceOptions = Configuration.GetSection("TCMBServiceOptions").Get<TCMBServiceOptions>();
            services.Configure<TCMBServiceOptions>(Configuration.GetSection("TCMBServiceOptions"));

            Microsoft.OpenApi.Models.OpenApiInfo inf = new Microsoft.OpenApi.Models.OpenApiInfo();
            inf.Title = "TCMB API";
            inf.Description = "TCMB API SWAGGER DOCUMENT";

        
            services.AddTCMBInfrastructure(Configuration);
         


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", inf);

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.UseInlineDefinitionsForEnums();
                ////c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionMiddleWare();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TCMB API"));
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
