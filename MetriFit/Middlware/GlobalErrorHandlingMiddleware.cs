namespace MetriFit.Middlware
{
    public class GlobalErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;


        public GlobalErrorHandlingMiddleware(ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
              

                ResponseResult response = new ResponseResult(ex.Message);

                await HandlingResponse(context,  response);
            }
           
        }
        public async Task HandlingResponse(HttpContext context, ResponseResult response)
        {
            string json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(json);    

        }
    }
}
