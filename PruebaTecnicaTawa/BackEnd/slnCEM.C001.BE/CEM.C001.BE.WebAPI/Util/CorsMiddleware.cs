using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CEM.C001.BackEnd.WebAPI
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate, pre-check=0, post-check=0, max-age=0, s-maxage=0");
            httpContext.Response.Headers.Add("Pragma", "no-cache");
            httpContext.Response.Headers.Add("Expires", "0");

            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");            
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");

            httpContext.Response.Headers.Add("X-Frame-Options", "DENY");
            httpContext.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            httpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            httpContext.Response.Headers.Add("Referrer-Policy", "no-referrer");
            httpContext.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
            httpContext.Response.Headers.Add("Content-Security-Policy", "default-src 'none'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; connect-src 'self'; form-action 'self';");
            httpContext.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
            httpContext.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'");
            httpContext.Response.Headers.Remove("X-Powered-By");

            return _next(httpContext);
        }
    }

    public static class CorsMiddlewareExtensions{
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}