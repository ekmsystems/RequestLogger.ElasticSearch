using System;

namespace RequestLogger.ElasticSearch
{
    public class ElasticSearchRequestLog
    {
        public RequestData Request { get; set; }
        public ResponseData Response { get; set; }
        public Exception Error { get; set; }
    }
}