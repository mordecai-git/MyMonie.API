using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyMonie.Core.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonie.Core.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            _logger.LogError("Actual Error: {Error}", error);

            response.StatusCode = error switch
            {
                //case AppException e:
                //    // custom application error
                //    response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    break;
                KeyNotFoundException => (int)HttpStatusCode.NotFound,// not found error
                _ => (int)HttpStatusCode.InternalServerError,// unhandled error
            };
            JsonSerializerOptions options = new() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var result = JsonSerializer.Serialize(new ErrorResult
            {
                Success = false,
                Message = error?.Message,
                Status = response.StatusCode,
                Detail = error?.InnerException?.Message,
                Instance = Guid.NewGuid().ToString(),
                Path = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
                TraceInfo = GetErrorTraceInfo(error),
            }, options);

            _logger.LogError("Error: {@result}", result);

            await response.WriteAsync(result);
        }
    }

    private static TraceInfo GetErrorTraceInfo(Exception ex)
    {
        //Get a StackTrace object for the exception
        StackTrace st = new(ex, true);

        var traceInfo = new List<TraceInfo>();

        List<StackFrame> frames = st.GetFrames().Where(x => x.GetFileName() != null).ToList();

        var frame = frames.FirstOrDefault();

        if (frame == null) return new TraceInfo();

        TraceInfo trace = new()
        {
            FileName = frame.GetFileName(),
            MethodName = frame.GetMethod().Name,
            LineNumber = frame.GetFileLineNumber(),
            ColumnNumber = frame.GetFileColumnNumber()
        };

        return trace;

    }
}