using Newtonsoft.Json;

namespace Subscriber.WebApi.Configuration
{
    public class MiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MiddleWare> _looger;
        public MiddleWare(RequestDelegate next, ILogger<MiddleWare> looger)
        {
            this.next = next;
            _looger = looger;
        }

        public async Task Invoke(HttpContext cont)
        {
            try
            {
                await next(cont);
                _looger.LogInformation($"the function: {cont.Request.Method} finished ");
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(cont, e);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response= JsonConvert.SerializeObject(new { error = ex.Message });         
            return context.Response.WriteAsync(response);
        }

    }
}
