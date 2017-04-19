using System;
using Microsoft.AspNetCore.Builder;

namespace Bit0.Utils.JSend.Http.Exception
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/> extension methods for the <see cref="JSendExceptionInterceptor"/>.
    /// </summary>
    public static class JSendExceptionInterceptorExtension
    {
        /// <summary>
        /// Captures synchronous and asynchronous <see cref="Exception"/> instances from the pipeline and generates JSend error responses.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <returns>A reference to the <paramref name="app"/> after the operation has completed.</returns>
        public static IApplicationBuilder UseJSendExceptionInterceptor(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<JSendExceptionInterceptor>();
        }
    }
}
