using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odeon.TCMB.UnitTests.Application
{
    [TestClass]
    public class XmlRead_Test
    {
        private IXmlRead _xmlReadService;
        private string url;
        [TestInitialize]
        public void Initialize()
        {
            _xmlReadService = new XmlReadService();
            url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ValidateXmlRead_WhenUrlNull_ShouldValidationException()
        {
            var xdoc = _xmlReadService.GetDocument(null).Result;
        }

        [TestMethod]
        public void XmlRead_ShouldBeHaveNode()
        {
            var xdocActual = _xmlReadService.GetDocument(url).Result;
            Assert.AreEqual(true, xdocActual.Nodes().Any());
        }
    }
}
