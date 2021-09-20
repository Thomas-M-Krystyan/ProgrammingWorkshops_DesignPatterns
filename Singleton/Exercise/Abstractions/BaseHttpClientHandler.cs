using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations.Abstractions
{
    public abstract class BaseHttpClientHandler : IHttpClientHandler
    {
        private readonly IHttpClientFactory _clientFactory;

        private int _clientId;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHttpClientHandler"/> class.
        /// </summary>
        /// <param name="clientFactory">The client factory.</param>
        protected BaseHttpClientHandler(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse(string requestUri)
        {
            try
            {
                var client = this._clientFactory.CreateClient();
                this._clientId = client.GetHashCode();
                var result = await client.GetAsync(requestUri);

                return result.StatusCode;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
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
