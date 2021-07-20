using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftMediaClubTestTask.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.API.Middlewares
{
    public class ApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;
        private const string DEFAULT_ERROR_DETAIL = "Internal server error occured";

        public ApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound, true);
            }
            catch (BadArgumentException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, true);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError, bool showMessage = false)
        {
            _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");

            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Error occured",
                Status = (int)httpStatusCode,
                Instance = context.Request.Path,
                Detail = showMessage ? ex.Message : DEFAULT_ERROR_DETAIL
            };

            context.Response.StatusCode = (int)httpStatusCode;
            var result = JsonSerializer.Serialize(problemDetails);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
