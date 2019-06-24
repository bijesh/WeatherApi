using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using Moq;
using NUnit.Framework;
using WeatherApi.Utilities;

namespace WeatherApi.Test.Utilities
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class HttpRequestBuilderTests
    {
        private HttpRequestBuilder _httpRequestBuilder;

        [SetUp]
        public void Setup()
        {
            _httpRequestBuilder = new HttpRequestBuilder();
        }

        [Test]
        public void GetHttpRequestMessage_Returns_HttpRequestMessage()
        {
            Assert.IsNotNull(_httpRequestBuilder.GetHttpRequestMessage(It.IsAny<Uri>(),HttpMethod.Get));
        }

        [Test]
        public void GetHttpRequestMessage_Sets_Request_Uri()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"),HttpMethod.Get);
            Assert.IsNotNull(requestMessage.RequestUri);
        }

        [Test]
        public void GetHttpRequestMessage_Sets_HttpMethod()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"),HttpMethod.Get);
            Assert.IsNotNull(requestMessage.Method);
        }

        [Test]
        public void GetHttpRequestMessage_Sets_ContentTypeHeader()
        {
            var requestMessage = _httpRequestBuilder.GetHttpRequestMessage(new Uri("http://localhost"),HttpMethod.Get);
            Assert.IsTrue(requestMessage.Headers.Accept.Any(x => x.MediaType == "application/json"));
        }
        
    }
}
