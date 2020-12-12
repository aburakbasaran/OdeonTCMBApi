using Application.DomainObjects;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.RateOperation;
using Application.Services.RateStrategies;
using Domain.DomainObject.TCMB;
using Domain.Enums;
using Domain.Models.TCMB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TCMBService : ITCMBService
    {
        private IXmlRead _xmlRead;
        private IGetXmlToObjectWithParam _getXmlToObject;
        private IXmlFileBuilder _xmlbuilder;
        private ICsvFileBuilder _csvbuilder;
        private readonly TCMBServiceOptions _tcmbServiceOptions;
        public TCMBService(IXmlRead xmlRead, IGetXmlToObjectWithParam getXmlToObject, IXmlFileBuilder xmlbuilder, ICsvFileBuilder csvbuilder , IOptions<TCMBServiceOptions> tcmbOptions)
        {
            this._tcmbServiceOptions = tcmbOptions.Value;
            this._xmlRead = xmlRead;
            this._getXmlToObject = getXmlToObject;
            this._xmlbuilder = xmlbuilder;
            this._csvbuilder = csvbuilder;

        }


        public Task<byte[]> GetTCMBExchangeRateFile(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0, ExportType exportType = ExportType.CSV, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered)
        {

            TCMBXmlOperation xmlOperation;

            try
            {
                var tcmbXmlDoc = this._xmlRead.GetDocument(this._tcmbServiceOptions.Url).Result;

                var exchangeRate = this._getXmlToObject.GetExchangeRate(tcmbXmlDoc, currencyCode, unit, rateCurrenyOrderType).Result;

                if (exportType == ExportType.XML)
                    xmlOperation = new TCMBXmlOperation(new TCMBXmlStrategy(this._xmlbuilder));
                else
                    xmlOperation = new TCMBXmlOperation(new TCMBCsvStrategy(this._csvbuilder));

                return xmlOperation.GetTCMBExchangeRate(exchangeRate);
            }
            catch (Exception ex)
            {
                throw new NotFoundException("One or more errors occurred");
            }
        }

        public Task<ResponseDTO<List<ResponseCurrencyDO>>> GetTCMBExchangeRate(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0,  RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered)
        {
            ResponseDTO<List<ResponseCurrencyDO>> result = new();

            try
            {
                var tcmbXmlDoc = this._xmlRead.GetDocument(this._tcmbServiceOptions.Url).Result;

                var exchangeRate = this._getXmlToObject.GetExchangeRate(tcmbXmlDoc, currencyCode, unit, rateCurrenyOrderType).Result;

                result.Data = (from cr in exchangeRate.Currencies
                               select new ResponseCurrencyDO(cr.Isim, cr.ForexBuying, cr.ForexSelling, cr.CurrencyCode)).ToList();

                result.IsSuccessfull = true;

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
            }


            return Task.FromResult(result);

        }
    }
}
