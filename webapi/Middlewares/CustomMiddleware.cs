using Microsoft.AspNetCore.Diagnostics;

namespace webapi.Middlewares
{
    public class CustomMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> Logger;
        private readonly RequestDelegate Pipeline;
        public CustomMiddleware(RequestDelegate Pipeline, ILogger<ExceptionHandlerMiddleware> Logger)
        {
            this.Logger = Logger;
            this.Pipeline = Pipeline;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Before Execution
                await Pipeline(context).ConfigureAwait(false);
                // After Execution
            }
            catch (BadHttpRequestException _)
            {
                // Ignore those exceptions since they are created by connection errors and not our code
            }
            catch (Exception ex)
            {
                Logger.LogError(exception: ex, $"Uncaught Exception. Message => \"{ex.Message}\"");
                throw;
            }
        }
    }
}
