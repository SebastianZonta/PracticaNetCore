using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TutorialASPNETCore.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("Error/{statuscode}")]
        public IActionResult HttpHandler(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statuscode)
            {
                case 404:
                    ViewBag.Message = "The request can be reached sorry puto";
                    logger.LogWarning($"404 error ocurred path {statusCodeResult.OriginalPath}");
                    break;
                
            }
            return View("Not found");
        }
        [Route("/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails=HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //ViewBag.ExceptionDetails = exceptionDetails.Path;
            //ViewBag.Message = exceptionDetails.Error.Message;
            //ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;
            logger.LogError($"The path{exceptionDetails.Path} threw an exception {exceptionDetails.Error}");
            return View("Error");

        }
    }
}
