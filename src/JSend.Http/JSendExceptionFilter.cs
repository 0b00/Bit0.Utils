using System;
using Bit0.Utils.JSend.Exceptions;
using Bit0.Utils.JSend.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Bit0.Utils.JSend.Http
{
    /// <summary>
    /// JSend Exception Filter
    /// </summary>
    public class JSendExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        /// <summary>
        /// JSend Exception Filter
        /// </summary>
        /// <param name="loggerFactory">Logger factory</param>
        public JSendExceptionFilter(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _logger = loggerFactory.CreateLogger(GetType());
        }

        /// <summary>
        /// Execute on exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            JsonResult jsonResult;

            if (context.Exception is JSendException)
            {
                var exception = (JSendException) context.Exception;
                jsonResult = new JsonResult(exception.ResponseObject)
                {
                    StatusCode = exception.StatusCode
                };
            }
            else
            {
                var jsend = new ErrorResponse(context.Exception.Message);
                jsonResult = new JsonResult(jsend)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            context.Result = jsonResult;
            context.HttpContext.Response.ContentType = "application/json";

            _logger.LogError(context.Exception.Message, context.Exception);

            base.OnException(context);
        }
    }
}