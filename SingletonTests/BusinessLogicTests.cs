using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Singleton.Exercise.Implementations;
using Singleton.Exercise.Implementations.Abstractions;
using Singleton.Exercise.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SingletonTests
{
    [TestFixture]
    public class Tests
    {
        private readonly HashSet<int> _clientIds = new();

        [TestCaseSource(nameof(HttpClientHandlers))]
        public async Task CheckIfMethod_GetResponse_ReturnsOkStatusCode(IHttpClientHandler httpClientHandler)
        {
            Assert.That(await httpClientHandler.GetResponse("http://webcode.me"), Is.EqualTo(HttpStatusCode.OK));
            TestContext.WriteLine(httpClientHandler.GetImplementationName());
        }
        
        [TestCaseSource(nameof(HttpClientHandlers))]
        public void CheckIfMethod_GetClientId_ReturnsTheSameId(IHttpClientHandler httpClientHandler)
        {
            this._clientIds.Add(httpClientHandler.GetClientId());
            
            Assert.That(this._clientIds.Count, Is.EqualTo(1), message: "Expected is to have only a single unique client ID");
            TestContext.WriteLine(httpClientHandler.GetImplementationName());
        }

        private static IHttpClientHandler[] HttpClientHandlers()
        {
            var logger = new NullLogger<BaseHttpClientHandler>();

            Mock<IHttpClientFactory> _clientFactory = new();
            _clientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                          .Returns(new HttpClient());

            var httpClientFactory = _clientFactory.Object;

            return new IHttpClientHandler[]
            {
                new BusinessLogic1(logger, httpClientFactory),
                new BusinessLogic2(logger, httpClientFactory),
                new BusinessLogic3(logger, httpClientFactory),
                new BusinessLogic4(logger, httpClientFactory)
            };
        }
    }
}
