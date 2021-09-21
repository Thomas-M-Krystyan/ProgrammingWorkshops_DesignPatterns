using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Singleton.Exercise.Implementations;
using Singleton.Exercise.Implementations.Abstractions;
using Singleton.Exercise.Interfaces;
using Singleton.Exercise.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SingletonTests
{
    [TestFixture]
    public class Tests
    {
        private readonly List<HttpClient> _totalItemsAmount = new();
        private readonly HashSet<HttpClient> _uniqueItems = new();

        [OneTimeTearDown]
        public void CleanupAfterAllTests()
        {
            HttpClientSingleton.Dispose();
        }

        [TestCaseSource(nameof(HttpClientHandlers_Factory))]
        [TestCaseSource(nameof(HttpClientHandlers_Singleton))]
        public async Task CheckIfMethod_GetResponse_ReturnsOkStatusCode(IHttpClientHandler httpClientHandler)
        {
            TestContext.WriteLine(httpClientHandler.GetImplementationName());

            Assert.That(await httpClientHandler.GetResponse("http://webcode.me"), Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CheckIfMethod_GetClientId_ReturnsTheSameId()
        {
            // NOTE: When checking unique client ID the expected result can be achieved if mocked HttpClientFactory is set up once
            CheckClientIds("Factory", HttpClientHandlers_Factory());

            // NOTE: When checking unique client ID we are always using the same HttpClient. It does not matter how many times the implementation will be called
            CheckClientIds("Singleton", HttpClientHandlers_Singleton());
        }

        private void CheckClientIds(string outputIdentifier, IHttpClientHandler[] dataSource)
        {
            this._totalItemsAmount.Clear();
            this._uniqueItems.Clear();

            foreach (var dataItem in dataSource)
            {
                // Act
                var client = dataItem.GetClient();

                // Assert
                this._totalItemsAmount.Add(client);
                this._uniqueItems.Add(client);

                TestContext.WriteLine($"{outputIdentifier} sample: {this._totalItemsAmount.Count} / {dataSource.Length}");

                Assert.That(this._uniqueItems.Count, Is.EqualTo(1), message: "Expected is to have only a single unique client ID");
            }
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
