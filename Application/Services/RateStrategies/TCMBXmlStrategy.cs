using Application.Interfaces;
using Domain.Models.TCMB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RateStrategies
{
    internal class TCMBXmlStrategy : IExchangeRate
    {
        private IXmlFileBuilder _xmlbuilder;
        public TCMBXmlStrategy(IXmlFileBuilder xmlFileBuilder)
        {
            this._xmlbuilder = xmlFileBuilder;
        }
        public Task<byte[]> GetExchangeRates(ExchangeRates exchangeRates)
        {
            return Task.FromResult(_xmlbuilder.BuildExchangeRatesFile(exchangeRates));
        }
    }
}
