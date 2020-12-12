using Application.Interfaces;
using Application.Services.Xml;
using Application.Services.XmlToObjectWithParam;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTCMBApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGetXmlToObjectWithParam, GetXmlToObjectWithParam>();
            services.AddScoped<IXmlRead, XmlReadService>();
            return services;
        }
    }
}
