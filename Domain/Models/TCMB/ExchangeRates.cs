using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Domain.Models.TCMB
{

    [Serializable()]
    public record ExchangeRates 
    {
        public List<Currency> Currencies { get; private set; }
        public string Tarih { get;  set; }
        public string Date { get;  set; }
        public string BultenNo { get;  set; }

        public ExchangeRates(List<Currency> _currencies, string _tarih, string _date, string _bultenNo)
        {
            this.Currencies = _currencies;
            this.Tarih = _tarih;
            this.Date = _date;
            this.BultenNo = _bultenNo;
        }

        public ExchangeRates()
        {
            this.Currencies = new();
        }
      
    }
}
