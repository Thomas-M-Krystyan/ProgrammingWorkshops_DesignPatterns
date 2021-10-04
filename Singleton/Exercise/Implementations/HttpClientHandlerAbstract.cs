using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Singleton.Exercise.Interfaces;
using Singleton.Exercise.Service;

namespace Singleton.Exercise.Implementations
{
    public abstract class HttpClientHandlerAbstract : IHttpClientHandler
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient = HTTPClientSingleService.GetInstance();
        public HttpClientHandlerAbstract(ILogger logger)
        {
            _logger = logger;
        }
        public async  Task<HttpStatusCode> GetResponse(string webUri)
        {
            try
            {
                var result = await this._httpClient.GetAsync(webUri);
                _logger.LogInformation($"INFO: {webUri} is {result.StatusCode}");
                return result.StatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HttpStatusCode.NotFound;
            }
        }

        public int GetClientId()
        {
            return _httpClient.GetHashCode();
        }

        public abstract string GetImplementationName();
    }
}
