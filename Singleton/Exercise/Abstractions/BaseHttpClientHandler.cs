using Microsoft.Extensions.Logging;
using Singleton.Exercise.Interfaces;
using Singleton.Exercise.Services;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHttpClientHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        protected BaseHttpClientHandler(ILogger<BaseHttpClientHandler> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHttpClientHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="clientFactory">The client factory.</param>
        protected BaseHttpClientHandler(ILogger<BaseHttpClientHandler> logger, IHttpClientFactory clientFactory) : this(logger)
        {
            this._clientFactory = clientFactory;
        }

        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse(string requestUri)
        {
            try
            {
                // HTTP Client
                var client = GetClient();  // NOTE: Factory controls lifespan of "client" instance. You do not need to dispose it

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
        public HttpClient GetClient()
        {
            // NOTE: Further reading => https://www.rahulpnath.com/blog/are-you-using-httpclient-in-the-right-way/
            return this._clientFactory != null ? this._clientFactory.CreateClient()
                                               : HttpClientSingleton.GetClient();
        }

        /// <inheritdoc />
        public abstract string GetImplementationName();
    }
}
