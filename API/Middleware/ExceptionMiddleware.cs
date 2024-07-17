using API.Models;
using Application.Contracts.ILogging;
using Application.Exceptions;
using Azure;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Text.Json.Serialization;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        //private readonly IAppLogger<ExceptionMiddleware> _appLogger;

        public ExceptionMiddleware(RequestDelegate requestDelegate/*, IAppLogger<ExceptionMiddleware> appLogger*/)
        {
            _requestDelegate = requestDelegate;
            //_appLogger = appLogger ?? throw new ArgumentNullException(nameof(_appLogger));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemsDetails problem = new();

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemsDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors
                    };
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemsDetails
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = notFoundException.InnerException?.Message,
                    };
                    break;
                default:
                    problem = new CustomProblemsDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Detail = ex.StackTrace,
                    };
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            //var logMessage = JsonConvert.SerializeObject(problem);
            //_appLogger.LogError(logMessage);
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
