using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Xml;
using Application.Services.XmlToObjectWithParam;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Odeon.TCMB.UnitTests.Application
{
    [TestClass]
    public class GetXmlToObjectWithParam_Test
    {
        private IGetXmlToObjectWithParam _getXmlToObject;
        private IXmlRead _xmlReadService;
        private string url;
        [TestInitialize]
        public void Initialize()
        {
            _getXmlToObject = new GetXmlToObjectWithParam();
            _xmlReadService = new XmlReadService();
            url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ValidateGetXmlToObjectWithParam_CurrencyRangeMax_Test()
        {
            var xdoc = _xmlReadService.GetDocument(url).Result;
            var result = _getXmlToObject.GetExchangeRate(xdoc, (Domain.Enums.CurrencyCodes)120, 0, Domain.Enums.RateCurrenyOrderType.CrossOrdered).Result;
            
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ValidateGetXmlToObjectWithParam_CurrencyRangeMin_Test()
        {
            var xdoc = _xmlReadService.GetDocument(url).Result;
            var result = _getXmlToObject.GetExchangeRate(xdoc, (Domain.Enums.CurrencyCodes)(-1), 0, Domain.Enums.RateCurrenyOrderType.CrossOrdered).Result;

        }

        [TestMethod]
        [ExpectedException(typeof(XmlReadException))]
        public void ValidateGetXmlToObjectWithParam_XmlHasValue_Test()
        {
            var xdoc = new XDocument();
            var result = _getXmlToObject.GetExchangeRate(xdoc, Domain.Enums.CurrencyCodes.All, 0, Domain.Enums.RateCurrenyOrderType.CrossOrdered).Result;
        }
    }
}
