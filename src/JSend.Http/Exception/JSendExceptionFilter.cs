using System;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.JSend.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Bit0.Utils.JSend.Http.Exception
{
    /// <summary>
    /// JSend Exception Filter
    /// </summary>
    public class JSendExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Execute on exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            JsonResult jsonResult;

            if (context.Exception is ExceptionBase exception)
            {
                jsonResult = new JsonResult(exception.ResponseObject)
                {
                    StatusCode = exception.StatusCode
                };
            }
            else
            {
                var jsend = new ErrorResponse(context.Exception.Message, context.Exception);
                jsonResult = new JsonResult(jsend)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            context.Result = jsonResult;
            context.HttpContext.Response.ContentType = "application/json";

            base.OnException(context);
        }
    }
}