using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Fourth implementation using <seealso cref="HttpClient"/> resource created internally on demand.
    /// </summary>
    public sealed class BusinessLogic4 : IHttpClientHandler
    {
        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync("http://webcode.me");

            return result.StatusCode;
        }

        /// <inheritdoc />
        public int GetClientId()
        {
            return 12345678;
        }

        /// <inheritdoc />
        public string GetImplementationName()
        {
            return nameof(BusinessLogic4);
        }
    }
}
