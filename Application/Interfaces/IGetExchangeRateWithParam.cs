using Domain.Enums;
using Domain.Models.TCMB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Interfaces
{
    public interface IGetXmlToObjectWithParam
    {
        Task<ExchangeRates> GetExchangeRate(XDocument xDoc, CurrencyCodes currencyCodes = CurrencyCodes.All, long unit = 0, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered);
    }
}
