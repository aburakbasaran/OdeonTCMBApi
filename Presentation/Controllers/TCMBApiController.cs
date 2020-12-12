using Application.DomainObjects;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TCMBApiController : ApiController
    {

        ITCMBService _tcmbService;

        public TCMBApiController(ITCMBService tcmbService)
        {
            this._tcmbService = tcmbService;
        }


        [HttpGet("GetTCMBExchangeCurrenciesFile")]
        public FileContentResult GetTCMBExchangeCurrenciesFile(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0, ExportType exportType = ExportType.CSV, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered)
        {
            var byteArray = this._tcmbService.GetTCMBExchangeRateFile(currencyCode, unit, exportType, rateCurrenyOrderType).Result;
            var result = new FileContentResult(byteArray, "application/octet-stream");

            if (exportType == ExportType.CSV)
                result.FileDownloadName = DateTime.Now.ToShortDateString() + "currencies.csv";
            else
                result.FileDownloadName = DateTime.Now.ToShortDateString() + "currencies.xml";

            return result;
        }

        [HttpGet("GetTCMBExchangeCurrencies")]
        public IActionResult GetTCMBExchangeCurrencies(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered)
        {
            return Response(this._tcmbService.GetTCMBExchangeRate(currencyCode, unit, rateCurrenyOrderType).Result);

        }


        [HttpGet("GetTCMBExchangeCurrenciesBytes")]
        public IActionResult GetTCMBExchangeCurrenciesBytes(CurrencyCodes currencyCode = CurrencyCodes.All, long unit = 0, ExportType exportType = ExportType.CSV, RateCurrenyOrderType rateCurrenyOrderType = RateCurrenyOrderType.CrossOrdered)
        {
            var byteArray = this._tcmbService.GetTCMBExchangeRateFile(currencyCode, unit, exportType, rateCurrenyOrderType).Result;

            ResponseDTO<Dictionary<string, byte[]>> result = new();

            string fileName;

            if (exportType == ExportType.CSV)
                fileName = DateTime.Now.ToShortDateString() + "currencies.csv";
            else
                fileName = DateTime.Now.ToShortDateString() + "currencies.xml";

            Dictionary<string, byte[]> resultData = new();
            resultData.Add(fileName, byteArray);

            result.Data = resultData;

            return Response(result);
        }




    }
}
