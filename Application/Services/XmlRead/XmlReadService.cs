using Application.Exceptions;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Application.Services.Xml
{
   public class XmlReadService : IXmlRead
    {
        public Task<XDocument> GetDocument(string uri)
        {

            if (string.IsNullOrWhiteSpace(uri))
                throw new ValidationException("Xml url is not empty.");


            XDocument xDoc = XDocument.Load(uri);

            if (xDoc == null)
                throw new NotFoundException(uri + " not response for xml loading.");

            return Task.FromResult(xDoc);

        }


    }
}
