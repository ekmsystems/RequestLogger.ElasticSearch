using System;

namespace RequestLogger.ElasticSearch
{
    public class ElasticSearchLogger : IRequestLogger
    {
        public void Log(RequestData requestData, ResponseData responseData)
        {
            throw new NotImplementedException();
        }

        public void LogError(RequestData requestData, ResponseData responseData, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}