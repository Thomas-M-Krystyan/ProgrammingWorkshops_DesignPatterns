using NUnit.Framework;
using Singleton.Exercise.Implementations;
using Singleton.Exercise.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SingletonTests
{
    public class Tests
    {
        private readonly HashSet<int> _clientIds = new();

        [TestCaseSource(nameof(HttpClientHandlers))]
        public async Task CheckIfMethod_GetResponse_ReturnsOkStatusCode(IHttpClientHandler httpClientHandler)
        {
            Assert.That(await httpClientHandler.GetResponse(), Is.EqualTo(HttpStatusCode.OK));
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
            return new IHttpClientHandler[]
            {
                new BusinessLogic1(),

                new BusinessLogic2(),
                new BusinessLogic2(new HttpClient()),

                new BusinessLogic3(),
                new BusinessLogic3
                {
                    HttpClient = new HttpClient()
                },

                new BusinessLogic4()
            };
        }
    }
}
