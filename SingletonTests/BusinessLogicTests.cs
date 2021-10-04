using NUnit.Framework;
using Singleton.Exercise.Implementations;
using Singleton.Exercise.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SingletonTests
{
    public class Tests
    {
        private readonly HashSet<int> _clientIds = new HashSet<int>();

        [TestCaseSource(nameof(HttpClientHandlers))]
        public async Task CheckIfMethod_GetResponse_ReturnsOkStatusCode(IHttpClientHandler httpClientHandler)
        {
            string weburi = "http://webcode.me";
            Assert.That(await httpClientHandler.GetResponse(weburi), Is.EqualTo(HttpStatusCode.OK));
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
            var logger = new NullLogger<HttpClientHandlerAbstract>();
            return new IHttpClientHandler[]
            {
                new BusinessLogic1(logger),

                new BusinessLogic2(logger),
               
                new BusinessLogic3(logger),             

                new BusinessLogic4(logger)
            };
        }
    }
}
