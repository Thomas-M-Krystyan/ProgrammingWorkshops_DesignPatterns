using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Singleton.Exercise.Implementations;
using Singleton.Exercise.Implementations.Abstractions;
using Singleton.Exercise.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SingletonTests
{
    [TestFixture]
    public class Tests
    {
        private readonly HashSet<int> _clientIds = new();

        [TestCaseSource(nameof(HttpClientHandlers_Factory))]
        [TestCaseSource(nameof(HttpClientHandlers_Singleton))]
        public async Task CheckIfMethod_GetResponse_ReturnsOkStatusCode(IHttpClientHandler httpClientHandler)
        {
            Assert.That(await httpClientHandler.GetResponse("http://webcode.me"), Is.EqualTo(HttpStatusCode.OK));
            TestContext.WriteLine(httpClientHandler.GetImplementationName());
        }

        // NOTE: When checking unique client ID the expected result can be achieved only if mocked HttpClientFactory is set up once
        [TestCaseSource(nameof(HttpClientHandlers_Factory))]
        // NOTE: When checking unique client ID we are always using the same HttpClient. So, does not matter how many times the implementation will be called
        [TestCaseSource(nameof(HttpClientHandlers_Singleton))]
        public void CheckIfMethod_GetClientId_ReturnsTheSameId(IHttpClientHandler httpClientHandler)
        {
            var clientId = httpClientHandler.GetClientId();

            this._clientIds.Add(clientId);

            Assert.That(this._clientIds.Count, Is.EqualTo(1), message: "Expected is to have only a single unique client ID");
            TestContext.WriteLine($"{httpClientHandler.GetImplementationName()}: {clientId}");
        }

        private static IHttpClientHandler[] HttpClientHandlers_Factory()
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

        private static IHttpClientHandler[] HttpClientHandlers_Singleton()
        {
            var logger = new NullLogger<BaseHttpClientHandler>();

            return new IHttpClientHandler[]
            {
                new BusinessLogic1(logger),
                new BusinessLogic1(logger),
                new BusinessLogic1(logger),

                new BusinessLogic2(logger),
                new BusinessLogic2(logger),

                new BusinessLogic3(logger),

                new BusinessLogic4(logger),
                new BusinessLogic4(logger)
            };
        }
    }
}
