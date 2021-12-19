using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class TodoAppExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<TodoAppExceptionFilter> _logger;
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public TodoAppExceptionFilter(ILogger<TodoAppExceptionFilter> logger)
        {
            _logger = logger;
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), context =>  SetExceptionResult(context, new BadRequestResult())},
                { typeof(NotFoundException), context => SetExceptionResult(context, new NotFoundResult()) },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            this.HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        
        private static void SetExceptionResult(ExceptionContext context, IActionResult result)
        {
            context.Result = result;

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var contextException = context.Exception;
            _logger.LogError(contextException, $"Unhandled exception: {contextException.Message}");

            SetExceptionResult(context, new StatusCodeResult(StatusCodes.Status500InternalServerError));
        }
    }
}
