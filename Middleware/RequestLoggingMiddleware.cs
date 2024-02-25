using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware_File_Address_Log.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware()
        {
        }

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestUrl = context.Request.Path + context.Request.QueryString;
            string logMessage = $"Requested URL: {requestUrl}\n";

            await LogRequest(logMessage);

            await _next(context);
        }

        public async Task LogRequest(string logMessage)
        {
            string filePath = @"D:\Visual Studio ШАГ\C#\Middleware-File-Address-Log\address.txt";
            await File.AppendAllTextAsync(filePath, logMessage);
        }
    }
}
