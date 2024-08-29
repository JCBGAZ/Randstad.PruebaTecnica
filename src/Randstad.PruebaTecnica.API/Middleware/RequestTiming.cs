using System.Diagnostics;

namespace Randstad.PruebaTecnica.API.Middleware
{
    public class RequestTiming(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;
            var logMessage = $"{context.Request.Method} {context.Request.Path} responded in {elapsedTime} ms";

            LogRequestTime(logMessage);
        }

        private static void LogRequestTime(string message)
        {
            var dateLog = DateTime.Now;
            var logFilePath = $"request_timing_log{dateLog.Day}_{dateLog.Month}_{dateLog.Year}.txt";
            using var writer = new StreamWriter(logFilePath, true);
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
