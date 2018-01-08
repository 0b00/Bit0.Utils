using Bit0.Utils.JSend.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bit0.Utils.JSend.Http
{
    /// <summary>
    /// JSend result filter
    /// </summary>
    public class JSendResultFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Execute while creating result
        /// </summary>
        /// <param name="context">Result context</param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (context.Controller is IJSendController)
            {
                context.Result = new OkObjectResult(new SuccessResponse(((ObjectResult)context.Result).Value));
            }
        }
    }
}
