using Application.Exceptions;
using Application.Interfaces;
using Domain.Models.TCMB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.Files
{
    public class XmlFileBuilder : IXmlFileBuilder
    {
        public byte[] BuildExchangeRatesFile(ExchangeRates records)
        {
            if (records.Currencies.Count==0)
                throw new NotFoundException();
            

            using var memoryStream = new MemoryStream();
            using (var sww = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Currency>));
                    xsSubmit.Serialize(writer, records.Currencies);
                 
                }
            }
            return memoryStream.ToArray();



        }
    }
}
