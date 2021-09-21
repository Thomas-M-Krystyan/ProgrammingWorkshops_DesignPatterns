using Microsoft.Extensions.Logging;
using Singleton.Exercise.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations.Abstractions
{
    public abstract class BaseHttpClientHandler : IHttpClientHandler
    {
        private readonly ILogger<BaseHttpClientHandler> _logger;
        private readonly IHttpClientFactory _clientFactory;

        private int _clientId;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHttpClientHandler"/> class.
        /// </summary>
        /// <param name="clientFactory">The client factory.</param>
        protected BaseHttpClientHandler(ILogger<BaseHttpClientHandler> logger, IHttpClientFactory clientFactory)
        {
            this._logger = logger;
            this._clientFactory = clientFactory;
        }

        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse(string requestUri)
        {
            try
            {
                // HTTP Client
                var client = this._clientFactory.CreateClient();
                this._clientId = client.GetHashCode();

                // Request
                var result = await client.GetAsync(requestUri);
                
                // Result
                var resultCode = result.StatusCode;

                this._logger.LogInformation($"Success: {requestUri} | {resultCode}");

                return resultCode;
            }
            catch (Exception exception)
            {
                this._logger.LogError(exception.Message);

                return HttpStatusCode.NotFound;
            }
        }

        /// <inheritdoc />
        public int GetClientId()
        {
            return this._clientId;
        }

        /// <inheritdoc />
        public abstract string GetImplementationName();
    }
}
