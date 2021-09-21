using MessagingServiceApp.Common.Results;
using MessagingServiceApp.Common.Results.Concrete;
using MessagingServiceApp.Common.Utilities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static MessagingServiceApp.Common.Utilities.SerilogExtensions;

namespace MessagingServiceApp.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.ForContext<ExceptionMiddleware>();
        }

        /// <summary>
        /// Invoke Exceptional Handling
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (BadRequestException ex)
            {
                await HandleError(context, ex.Message, StatusCodes.Status400BadRequest).ConfigureAwait(false);
            }
            catch (NotFoundException ex)
            {
                await HandleError(context, ex.Message, StatusCodes.Status404NotFound).ConfigureAwait(false);
            }
            catch (ValidatorException ex)
            {
                await HandleError(context, ex.Message, StatusCodes.Status400BadRequest).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex.Message, StatusCodes.Status500InternalServerError).ConfigureAwait(false);
            }
        }

        private async Task HandleError(HttpContext context, string ex, int statusCode)
        {
            var logModel = new LoggerModel
            {
                ResponseStatusCode = statusCode,
                InnerException = ex
            };

            _logger.PrepareLogger(logModel).Error(LoggerTemplates.Error);

            var responseModel = new ExceptionResponse
            {
                StatusCode = statusCode,
                Message = ex,
            };

            var responseBody = System.Text.Json.JsonSerializer.Serialize(responseModel, new JsonSerializerOptions
            {
                IgnoreNullValues = true
            });

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(responseBody, Encoding.UTF8).ConfigureAwait(false);
        }
    }
}
