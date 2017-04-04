using System;
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
            _logger = new ElasticSearchLogger();
        }

        private IRequestLogger _logger;

        [Test]
        public void Log_ShouldThrow_NotImplementedException()
        {
            var request = new RequestData();
            var response = new ResponseData();
            Assert.Throws<NotImplementedException>(() => _logger.Log(request, response));
        }

        [Test]
        public void LogError_ShouldThrow_NotImplementedException()
        {
            var request = new RequestData();
            var response = new ResponseData();
            var ex = new Exception();
            Assert.Throws<NotImplementedException>(() => _logger.LogError(request, response, ex));
        }
    }
}