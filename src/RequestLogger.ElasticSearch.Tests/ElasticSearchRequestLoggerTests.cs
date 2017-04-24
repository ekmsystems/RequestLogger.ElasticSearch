using System;
using Moq;
using Nest;
using NUnit.Framework;

namespace RequestLogger.ElasticSearch.Tests
{
    [TestFixture]
    [Parallelizable]
    public class ElasticSearchRequestLoggerTests
    {
        [SetUp]
        public void SetUp()
        {
            _client = new Mock<IElasticClient>();
            _requestLogger = new ElasticSearchRequestLogger(null, _client.Object);
        }

        private Mock<IElasticClient> _client;
        private IRequestLogger _requestLogger;

        [Test]
        public void Log_ShouldCall_Client_Index()
        {
            var request = new RequestData();
            var response = new ResponseData();

            _requestLogger.Log(request, response);

            _client.Verify(x => x.Index(It.Is<ElasticSearchRequestLog>(y =>
                    y.Request.Equals(request) &&
                    y.Response.Equals(response) &&
                    y.Error == null),
                It.IsAny<Func<IndexDescriptor<ElasticSearchRequestLog>, IIndexRequest>>()));
        }

        [Test]
        public void LogError_ShouldCall_Client_Index()
        {
            var request = new RequestData();
            var response = new ResponseData();
            var ex = new Exception();

            _requestLogger.LogError(request, response, ex);

            _client.Verify(x => x.Index(It.Is<ElasticSearchRequestLog>(y =>
                    y.Request.Equals(request) &&
                    y.Response.Equals(response) &&
                    y.Error == ex),
                It.IsAny<Func<IndexDescriptor<ElasticSearchRequestLog>, IIndexRequest>>()));
        }
    }
}