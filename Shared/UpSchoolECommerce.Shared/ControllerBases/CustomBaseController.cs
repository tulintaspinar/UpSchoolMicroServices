using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.DTOs;

namespace UpSchoolECommerce.Shared.ControllerBases
{
    public class CustomBaseController :  ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(ResponseDTO<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode=response.StatusCode
            };
        }
    }
}
