using CQRS.Domain.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace CQRS.API.Filters
{
    [ExcludeFromCodeCoverage]
    public class DefaultExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string DEFAULT_EXCEPTION = "Ocorreu um erro inesperado.";

        /// <summary>
        /// On Exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (context is null) return;

            var messageToException = DEFAULT_EXCEPTION;

            //var logger = context.HttpContext.RequestServices.GetService<ILogger<DefaultExceptionFilterAttribute>>();

            //if (logger is null) return;

            if (context.Exception is OperationCanceledException)
                messageToException = "Request was cancelled";

            //logger.LogError(context.Exception, context.Exception.Message);

            context.Result = new ObjectResult(new ResponseErrorAPI(false, messageToException, new List<string> { context.Exception.Message  }))
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };
        }
    }
}
