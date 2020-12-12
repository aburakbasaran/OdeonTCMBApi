using Application.DomainObjects;
using Domain.DomainObject.TCMB;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface ITCMBService
    {
        Task<byte[]> GetTCMBExchangeRateFile(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0, ExportType exportType = ExportType.CSV, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered);

        Task<ResponseDTO<List<ResponseCurrencyDO>>> GetTCMBExchangeRate(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered);
    }
}
