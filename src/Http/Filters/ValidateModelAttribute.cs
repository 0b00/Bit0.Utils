using System;
using System.Linq;
using Bit0.Utils.Http.Exceptions;
using Bit0.Utils.JSend.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bit0.Utils.Http.Filters
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context == null)
                throw new NullObjectException(nameof(context));

            var errors = context.ModelState.SelectMany(key => key.Value.Errors, (key, error) => new { field = key.Key, message = error.ErrorMessage }).ToList();

            if (errors.Any())
                throw new ModelValidationException(errors);

            base.OnActionExecuting(context);
        }
    }
}
