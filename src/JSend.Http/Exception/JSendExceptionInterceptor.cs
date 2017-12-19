using System.Threading.Tasks;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.JSend.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bit0.Utils.JSend.Http.Exception
{
    /// <summary>
    /// Captures synchronous and asynchronous exceptions from the pipeline and generates JSend error responses.
    /// </summary>
    public class JSendExceptionInterceptor
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JSendExceptionInterceptor"/> class
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public JSendExceptionInterceptor(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<JSendExceptionInterceptor>();
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(0, ex, "An unhandled exception has occurred while executing the request.");
                
                try
                {
                    if (context.Response.HasStarted)
                    {
                        _logger.LogWarning("The response has already started, the error page middleware will not be executed.");
                        throw;
                    }

                    context.Response.Clear();

                    DisplayException(context, ex);

                    return;
                }
                catch (System.Exception ex2)
                {
                    // If there's a Exception while generating the error page, re-throw the original exception.
                    _logger.LogError(0, ex2, "An exception was thrown attempting to display the error page.");
                }
                throw;
            }
        }

        private void DisplayException(HttpContext context, System.Exception ex)
        {
            JSendResponse jsend;
            //var jsend = ex is ExceptionBase exception ? exception.ResponseObject : new ErrorResponse(ex.Message, ex);
            if (ex is ExceptionBase exception)
            {
                var obj = exception.ResponseObject;
                if (obj.Data != null)
                {
                    jsend = new FailResponse(obj.Data, obj.StatusCode, obj.InnerStatus);
                }
                else
                {
                    jsend = new ErrorResponse(obj.Message, obj.StatusCode, obj.InnerStatus, obj.InnerException);
                }
            }
            else
            {
                jsend = new ErrorResponse(ex.Message, ex);
            }

            context.Response.StatusCode = jsend.StatusCode.Code;

            context.Response.ContentType = "application/json";
            context.Response.WriteAsync(JsonConvert.SerializeObject(jsend));

            _logger.LogError(ex.Message, ex);
        }
    }
}
