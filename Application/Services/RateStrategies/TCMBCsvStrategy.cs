using Application.Interfaces;
using Domain.Models.TCMB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RateStrategies
{
    internal class TCMBCsvStrategy : IExchangeRate
    {
        private ICsvFileBuilder _csvbuilder;
        public TCMBCsvStrategy(ICsvFileBuilder csvFileBuilder)
        {
            this._csvbuilder = csvFileBuilder;
        }
        public Task<byte[]> GetExchangeRates(ExchangeRates exchangeRates)
        {
            return Task.FromResult(_csvbuilder.BuildExchangeRatesFile(exchangeRates));
        }
    }
}
