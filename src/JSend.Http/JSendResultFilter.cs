using Bit0.Utils.JSend.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JSend.Http
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

            if (context.Controller is IJSendController) // TODO: Use an interface in future
            {
                context.Result = new OkObjectResult(new SuccessResponse(((ObjectResult)context.Result).Value));
            }
        }
    }
}
