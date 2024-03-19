using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LinkStorage.Controllers;

public class ErrorController : Controller
{
    [AllowAnonymous]
    [Route("Error")]
    public IActionResult Error(int? StatusCode)
    {
        var exceptionHandlerPathFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        
            ViewBag.ErrorMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StatusCode = StatusCode.Value;
        
        return View();
    }
    
    [Route("Error/{StatusCode}")]
    public IActionResult HttpStatusCodeHandler(int? StatusCode)
    {
        switch (StatusCode)
        {
            case 404:
                ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                ViewBag.StatusCode = StatusCode.Value;
                return View("NotFound");
                break;
            case 401:
                ViewBag.ErrorMessage = "Sorry, You are Unauthorized to access the resource ";
                ViewBag.StatusCode = StatusCode.Value;
                return View("Unauthorized");
                break;
        }

        return View("Error");
    }
}