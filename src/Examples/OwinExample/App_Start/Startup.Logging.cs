using Owin;
using RequestLogger.ElasticSearch;
using RequestLogger.Owin;

namespace OwinExample
{
    public partial class Startup
    {
        private static void ConfigureLogging(IAppBuilder app)
        {
            var requestLogger = new ElasticSearchRequestLogger();

            app.UseRequestLoggerMiddleware(requestLogger);

            app.Run(ctx =>
            {
                ctx.Response.ContentType = "text/plain";
                return ctx.Response.WriteAsync("Hello World");
            });
        }
    }
}