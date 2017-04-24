using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RequestLogger.ElasticSearch;
using RequestLogger.Web;

namespace AspNetExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly RequestLoggerModule RequestLoggerModule = CreateRequestLoggerModule();

        public override void Init()
        {
            base.Init();

            RequestLoggerModule.Init(this);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static RequestLoggerModule CreateRequestLoggerModule()
        {
            var requestLogger = new ElasticSearchRequestLogger();
            return new RequestLoggerModule(requestLogger);
        }
    }
}
