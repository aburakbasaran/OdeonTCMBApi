using Application.Interfaces;
using Application.Services;
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
            services.AddSingleton<IGetXmlToObjectWithParam, GetXmlToObjectWithParam>();
            services.AddSingleton<IXmlRead, XmlReadService>();
            services.AddSingleton<ITCMBService, TCMBService>();
            return services;
        }
    }
}
