using Application.Exceptions;
using Application.Interfaces;
using Infrastructure.Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Odeon.TCMB.UnitTests
{
    [TestClass]
    public class XmlFileBuilder_Test
    {


        private IXmlFileBuilder _xmlFileBuilder;
        private Domain.Models.TCMB.ExchangeRates exchangeRates;

        [TestInitialize]
        public void Initialize()
        {

            List<Domain.Models.TCMB.Currency> currencies = new();

            for (int i = 0; i < 2; i++)
                currencies.Add(new Domain.Models.TCMB.Currency(i, "Osmanli Akcesi", "Ottoman Lira", "1000", "200", "424", "424", "24", "424", 421, "OOL", "OOOL"));


            exchangeRates = new Domain.Models.TCMB.ExchangeRates(currencies, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), "2324");

            _xmlFileBuilder = new XmlFileBuilder();

        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void CSVFileBuilder_ShouldHaveExchangeCurrencyRate()
        {
            this._xmlFileBuilder.BuildExchangeRatesFile(new Domain.Models.TCMB.ExchangeRates());
        }

        [TestMethod]
        public void CSVFileBuilder_ShouldXmlToConvertCSV()
        {
            var byteArray = this._xmlFileBuilder.BuildExchangeRatesFile(exchangeRates);
            Assert.IsNotNull(byteArray);

        }
    }
}
