using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Singleton.Exercise.Service;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Fourth implementation using <seealso cref="HttpClient"/> resource created internally on demand.
    /// </summary>
    public sealed class BusinessLogic4 : IHttpClientHandler
    {
        private readonly HttpClient httpClient = HTTPClientSingleService.GetInstance();
        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse()
        {
            var result = await httpClient.GetAsync("http://webcode.me");

            return result.StatusCode;
        }

        /// <inheritdoc />
        public int GetClientId()
        {
           return httpClient.GetHashCode();
        }

        /// <inheritdoc />
        public string GetImplementationName()
        {
            return nameof(BusinessLogic4);
        }
    }
}
