using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Interfaces;
using Infrastructure.Files;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTCMBInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICsvFileBuilder, CsvFileBuilder>();
            services.AddScoped<IXmlFileBuilder, XmlFileBuilder>();
            services.AddTCMBApplication(configuration);
            return services;
        }
    }
}
