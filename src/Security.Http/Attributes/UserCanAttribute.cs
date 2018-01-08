using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Common.Extensions;
using Bit0.Utils.Security.Http.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Bit0.Utils.JSend.Http;
using Bit0.Utils.Security.Http.Auth.Requests;

namespace Bit0.Utils.Security.Http.Attributes
{
    /// <summary>
    /// Check if user can perform desired action.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class UserCanAttribute : ActionFilterAttribute
    {
        #region Private Fields

        private readonly RoleActionType _actionType;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Check if user can perform desired action
        /// </summary>
        /// <param name="actionType">Required action</param>
        public UserCanAttribute(RoleActionType actionType)
        {
            _actionType = actionType;
        }

        #endregion Public Constructors



        #region Public Methods
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is IJSendController controller))
            {
                throw new InvalidObjectTypeException(context.Controller.GetType(), typeof(IJSendController));
            }

            var type = controller.DataType;
            var typeName = type.Name.ToCamelCase();

            var ex = new InvalidCredentialsException(new
            {
                message = $"Current user is not allowed to {_actionType.GetValue()} {type.Name}."
            });

            if (!context.HttpContext.Items.ContainsKey(nameof(IAccessToken)))
            {
                throw ex;
            }

            if (!(context.HttpContext.Items[nameof(IAccessToken)] is IAccessToken accessToken))
            {
                throw ex;
            }

            if (!accessToken.Rights.ContainsKey(typeName) && !accessToken.Rights[typeName].HasFlag(_actionType))
            {
                throw ex;
            }
        }

        #endregion Public Methods
    }
}