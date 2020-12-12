using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainObject.TCMB
{
    public class ResponseCurrencyDO
    {
        public string Isim { get; private set; }
        public string ForexBuying { get; private set; }
        public string ForexSelling { get; private set; }
        public string CurrencyCode { get; private set; }


        public ResponseCurrencyDO(string _isim , string _forexBuying , string _forexSelling , string _currencyCode)
        {
            this.Isim = _isim;
            this.ForexBuying = _forexBuying;
            this.ForexSelling = _forexSelling;
            this.CurrencyCode = _currencyCode;
        }
    }
}
