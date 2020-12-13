using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DI.Middleware
{
    public class ExceptionMiddleware
    {
        RequestDelegate next;
 
        public ExceptionMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException ex)
            {
                //Log.Error($"Response Code: {"323"} Response: {ex.Message} ", ex);
                // response 
                throw;
            }
            catch (Exception ex)
            {
                //Log.Error($"Response Code: {"999"} Response: {ex.Message} ", ex);
                throw;

            }


        }
    }
}
