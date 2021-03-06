﻿using Application.Exceptions;
using Application.Interfaces;
using Domain.Enums;
using Domain.Models.TCMB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services.XmlToObjectWithParam
{
    public class GetXmlToObjectWithParam : IGetXmlToObjectWithParam
    {

        public GetXmlToObjectWithParam()
        {

        }


        private Task<ExchangeRates> GetExchangeRate(List<Currency> currencies, XDocument xDoc)
        {
            var exchangeRate = (from tcmb in xDoc.Elements("Tarih_Date")
                                select new ExchangeRates(currencies, tcmb.Attribute("Tarih").Value, tcmb.Attribute("Date").Value, tcmb.Attribute("Bulten_No").Value)).FirstOrDefault();

            return Task.FromResult(exchangeRate);


        }

        private Task<List<Currency>> GetCurrencies(XDocument xDoc, CurrencyCodes currencyCodes = CurrencyCodes.All, long unit = 0)
        {

            if (xDoc.FirstNode == null)
            {
                throw new XmlReadException();
            }


            var allCurrencies = (from tcmb in xDoc.Element("Tarih_Date").Elements("Currency")

                                 select new Currency(
                                                      Convert.ToInt64(tcmb.Element("Unit").Value),
                                                      tcmb.Element("Isim").Value,
                                                      tcmb.Element("CurrencyName").Value,
                                                      tcmb.Element("ForexBuying").Value,
                                                      tcmb.Element("ForexSelling").Value,
                                                      tcmb.Element("BanknoteBuying").Value,
                                                      tcmb.Element("BanknoteSelling").Value,
                                                      tcmb.Element("CrossRateUSD").Value,
                                                      tcmb.Element("CrossRateOther").Value,
                                                      Convert.ToInt64(tcmb.Attribute("CrossOrder").Value),
                                                      tcmb.Attribute("Kod").Value,
                                                      tcmb.Attribute("CurrencyCode").Value)).ToList();

            if (allCurrencies.Count == 0)
            {
                throw new XmlReadException();
            }



            var currencyQuery = allCurrencies.Where(x => 1 == 1);

            if (currencyCodes != CurrencyCodes.All)
                currencyQuery = currencyQuery.Where(x => x.CurrencyCode == currencyCodes.ToString());


            if (unit != 0)
                currencyQuery = currencyQuery.Where(x => x.Unit == unit);


            var currencies = currencyQuery.ToList();
            return Task.FromResult(currencies);

        }

        public Task<ExchangeRates> GetExchangeRate(XDocument xDoc, CurrencyCodes currencyCodes = CurrencyCodes.All, long unit = 0, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered)
        {
            ValidateGetExchangeRateRequest(xDoc, currencyCodes, rateCurrenyOrderType,unit);

            var allCurrencies = this.GetCurrencies(xDoc, currencyCodes, unit).Result;

            List<Currency> orderedCurrencies;

            if (rateCurrenyOrderType == RateCurrenyOrderType.CrossOrdered)
                orderedCurrencies = allCurrencies.OrderBy(x => x.CrossOrder).ToList();
            else
                orderedCurrencies = allCurrencies.OrderBy(x => x.CurrencyName).ToList();

            return GetExchangeRate(orderedCurrencies, xDoc);
        }

        private void ValidateGetExchangeRateRequest(XDocument xDocument, CurrencyCodes currencyCodes, RateCurrenyOrderType rateCurrenyOrderType , long unit )
        {
            var maxCurrency = Enum.GetValues(typeof(CurrencyCodes)).Cast<CurrencyCodes>().Last();
            var maxOrderType = Enum.GetValues(typeof(RateCurrenyOrderType)).Cast<RateCurrenyOrderType>().Last();

            if (currencyCodes.GetHashCode() > maxCurrency.GetHashCode() || currencyCodes.GetHashCode() < 0)
                throw new ValidationException();


            if (rateCurrenyOrderType.GetHashCode() > maxOrderType.GetHashCode() || rateCurrenyOrderType.GetHashCode() < 0)
                throw new ValidationException();


            if (xDocument == null)
                throw new ValidationException();

            if (xDocument == null)
                throw new ValidationException();

            if (unit<0)
                throw new ValidationException();
            

        }
    }
}
