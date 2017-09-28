using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Http.Exceptions;
using Bit0.Utils.Http.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using Xunit;


namespace Bit0.Utils.Tests.Http.Filters
{
    public class ValidateModelsTests
    {
        [Fact]
        public void Test()
        {
            var actionContext = new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor());
            var actionExecutingContext = new ActionExecutingContext(actionContext, new List<IFilterMetadata>(),  new Dictionary<string, object>(),  null);
            var validationFilter = new ValidateModelAttribute();

            validationFilter.OnActionExecuting(actionExecutingContext);

            actionContext.ModelState.AddModelError("Age", "Age cannot be below 18 years.");
            
            Assert.Throws<ModelValidationException>(() =>
            {
                validationFilter.OnActionExecuting(actionExecutingContext);
            });
            Assert.Throws<NullObjectException>(() =>
            {
                validationFilter.OnActionExecuting(null);
            });
        }
    }
}
