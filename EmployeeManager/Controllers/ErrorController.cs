using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpErrorHandler(int statusCode)
        {
            switch (statusCode)
            {
                
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the ressource you requested could not be found";
                    break;
                case 501:
                    ViewBag.ErroMessage = "Sorry, you request is not supported by the server";
                    break; 
                default:
                    break;
            }
            return View("NotFoundErrorView");
        }
    }
}
