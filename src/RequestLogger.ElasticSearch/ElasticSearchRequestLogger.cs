using System;
using Nest;

namespace RequestLogger.ElasticSearch
{
    public class ElasticSearchRequestLogger : IRequestLogger
    {
        private readonly ElasticSearchRequestLoggerConfiguration _config;
        private readonly IElasticClient _client;

        public ElasticSearchRequestLogger(ElasticSearchRequestLoggerConfiguration config = null)
            : this(config, new ElasticClient())
        {
        }

        public ElasticSearchRequestLogger(ElasticSearchRequestLoggerConfiguration config, IElasticClient client)
        {
            _config = config ?? new ElasticSearchRequestLoggerConfiguration
            {
                IndexName = "elastic-search-request-logger",
                TypeName = "request"
            };
            _client = client;
        }

        public void Log(RequestData requestData, ResponseData responseData)
        {
            PostLog(new ElasticSearchRequestLog
            {
                Request = requestData,
                Response = responseData
            });
        }

        public void LogError(RequestData requestData, ResponseData responseData, Exception ex)
        {
            PostLog(new ElasticSearchRequestLog
            {
                Request = requestData,
                Response = responseData,
                Error = ex
            });
        }

        private void PostLog(ElasticSearchRequestLog log)
        {
            _client.Index(log, i => i.Index(_config.IndexName).Type(_config.TypeName));
        }
    }
}