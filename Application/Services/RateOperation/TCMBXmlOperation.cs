using Application.Interfaces;
using Domain.Enums;
using Domain.Models.TCMB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services.RateOperation
{


    public class TCMBXmlOperation 
    {
        private IExchangeRate _exchangeRate;

        public TCMBXmlOperation(IExchangeRate exchangeRate)
        {
            this._exchangeRate = exchangeRate;
        }
        public Task<byte[]> GetTCMBExchangeRate(ExchangeRates exchangeRates)
        {
           return _exchangeRate.GetExchangeRates(exchangeRates);
        }
    }
}
