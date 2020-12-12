using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Models.TCMB
{
    [Serializable()]
    public record Currency
    {
        public long Unit { get;  set; }
        public string Isim { get;  set; }
        public string CurrencyName { get;  set; }
        public string ForexBuying { get;  set; }
        public string ForexSelling { get;  set; }
        public string BanknoteBuying { get;  set; }
        public string BanknoteSelling { get;  set; }
        public string CrossRateUsd { get;  set; }
        public string CrossRateOther { get;  set; }
        public long CrossOrder { get;  set; }
        public string Kod { get;  set; }
        public string CurrencyCode { get;  set; }

        public Currency(long _unit, string _isim, string _currencyName, string _forexBuying, string _forexSelling, string _banknoteBuying, string _banknoteSelling, string _crossRateUsd, string _crossRateOther, long _crossOrder, string _kod, string _currencyCode)
        {
            this.Unit = _unit;
            this.Isim = _isim;
            this.CurrencyName = _currencyName;
            this.ForexBuying = _forexBuying;
            this.ForexSelling = _forexSelling;
            this.BanknoteBuying = _banknoteBuying;
            this.BanknoteSelling = _banknoteSelling;
            this.CrossRateUsd = _crossRateUsd;
            this.CrossRateOther = _crossRateOther;
            this.CrossOrder = _crossOrder;
            this.Kod = _kod;
            this.CurrencyCode = _currencyCode;
        }

        public Currency()
        {

        }

      
    }
}
