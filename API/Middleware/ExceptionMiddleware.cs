using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Errors;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound,
                    "Resource not found, verify and try again!");
            }
            catch (EntityAlreadyExistsException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError,
                    "Data may have been modified or deleted. Please reload the page.");
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode, string customMessage = null)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)statusCode;
            _logger.LogInformation($"Request failed with status code {statusCode}" + $"/n {context.Response}");
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                message = customMessage ?? exception.Message,
                statusCode = statusCode
            }));
        }
    }
}