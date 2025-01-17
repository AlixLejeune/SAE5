namespace SAE501_Blazor_API.Security
{
    public class SecurityMiddleware
    {
        public static readonly string[] METHODS = ["POST", "PUT", "PATCH", "DELETE"];
        public static string API_KEY_NAME = "API_KEY";

        private readonly RequestDelegate _next;
        private readonly string? _apiKey;

        public SecurityMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _apiKey = config["ApiKey"];
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrEmpty(_apiKey) || !METHODS.Contains(context.Request.Method)) return _next(context);

            string? key = context.Request.Cookies[API_KEY_NAME];
            if(key == _apiKey) return _next(context);

            key = context.Request.Headers[API_KEY_NAME];
            if (key == _apiKey) return _next(context);

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
    }
}
