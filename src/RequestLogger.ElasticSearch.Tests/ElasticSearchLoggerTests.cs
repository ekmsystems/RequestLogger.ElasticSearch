using System;
using Moq;
using Nest;
using NUnit.Framework;

namespace RequestLogger.ElasticSearch.Tests
{
    [TestFixture]
    [Parallelizable]
    public class ElasticSearchLoggerTests
    {
        [SetUp]
        public void SetUp()
        {
            _client = new Mock<IElasticClient>();
            _logger = new ElasticSearchLogger(null, _client.Object);
        }

        private Mock<IElasticClient> _client;
        private IRequestLogger _logger;

        [Test]
        public void Log_ShouldCall_Client_Index()
        {
            var request = new RequestData();
            var response = new ResponseData();

            _logger.Log(request, response);

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

            _logger.LogError(request, response, ex);

            _client.Verify(x => x.Index(It.Is<ElasticSearchRequestLog>(y =>
                    y.Request.Equals(request) &&
                    y.Response.Equals(response) &&
                    y.Error == ex),
                It.IsAny<Func<IndexDescriptor<ElasticSearchRequestLog>, IIndexRequest>>()));
        }
    }
}