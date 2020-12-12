using Domain.Models.TCMB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExchangeRate
    {
        Task<byte[]> GetExchangeRates(ExchangeRates exchangeRates);
    }
}
