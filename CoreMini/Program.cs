using CoreMini.Host;
using CoreMini.Http;
using CoreMini.Server;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CoreMini
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new WebHostBuilder()
                .UseHttpListener()
                .Configure(app =>
                {
                    app.Use(FooMiddleware)
                    .Use(BarMiddleware)
                    .Use(BazMiddleware);
                })
                .Build()
                .StartAsync();
        }

        public static RequestDelegate FooMiddleware(RequestDelegate next)
   => async context =>
   {
       await context.Response.WriteAsync("Foo=>");
       await next(context);
   };

        public static RequestDelegate BarMiddleware(RequestDelegate next)
        => async context =>
        {
            await context.Response.WriteAsync("Bar=>");

            await next(context);
        };

        public static RequestDelegate BazMiddleware(RequestDelegate next)
        => context => context.Response.WriteAsync("Baz");
    }

    public static partial class Extensions
    {
        public static IWebHostBuilder UseHttpListener(this IWebHostBuilder builder, params string[] urls)
         => builder.UseServer(new HttpListenerServer(urls));

        public static Task WriteAsync(this HttpResponse response, string contents)
        {
            var buffer = Encoding.UTF8.GetBytes(contents);
            return response.Body.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
