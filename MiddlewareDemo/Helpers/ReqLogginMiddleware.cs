namespace MiddlewareDemo.Helpers
{
    public class ReqLogginMiddleware
    {
        private readonly RequestDelegate _next;
        public ReqLogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) { 

            //log each request
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            // Add an extra request parameter
            context.Request.QueryString = context.Request.QueryString.Add("newparam", "newValue");

            _next(context);
        }
    }
}
