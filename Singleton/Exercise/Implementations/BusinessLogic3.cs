using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using Singleton.Exercise.Service;

using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Third implementation using <seealso cref="System.Net.Http.HttpClient"/> resource injected through property.
    /// </summary>
    public sealed class BusinessLogic3 : IHttpClientHandler
    {
        public HttpClient HttpClient = HTTPClientSingleService.GetInstance();

        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse()
        {
            var result = await this.HttpClient.GetAsync("http://webcode.me");

            return result.StatusCode;
        }

        /// <inheritdoc />
        public int GetClientId()
        {
            return this.HttpClient.GetHashCode();
        }

        /// <inheritdoc />
        public string GetImplementationName()
        {
            return nameof(BusinessLogic3);
        }
    }
}
