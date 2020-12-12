using System;

using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Interfaces
{
    public interface IXmlRead
    {
        Task<XDocument> GetDocument(string uri);
    }
}
