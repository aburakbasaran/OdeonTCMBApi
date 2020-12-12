using Application.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response<T>(ResponseDTO<T> result)
        {
            if (result.IsSuccessfull)
                return Ok(result);
            else
            {
                result.Data = default(T);
                return Ok(result);
            }
        }
    }
}
