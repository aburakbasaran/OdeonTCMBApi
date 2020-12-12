using Domain.Models.TCMB;

namespace Application.Interfaces
{
    public interface IXmlFileBuilder
    {
        public byte[] BuildExchangeRatesFile(ExchangeRates records);
    }
}