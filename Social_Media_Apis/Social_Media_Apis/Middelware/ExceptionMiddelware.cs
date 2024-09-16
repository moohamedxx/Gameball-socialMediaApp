using Social_Media_Apis.Errors;
using System.Net;
using System.Text.Json;

namespace Social_Media_Apis.Middelware
{
    public class ExceptionMiddelware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddelware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddelware(RequestDelegate next , ILogger<ExceptionMiddelware> logger , IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                logger.LogError(e,e.Message);
                context.Response.ContentType = "Application/json";
                context.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var res = env.IsDevelopment() ?
                     new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, e.Message, e.StackTrace)
                     :
                     new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);
                var json = JsonSerializer.Serialize(res,options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
