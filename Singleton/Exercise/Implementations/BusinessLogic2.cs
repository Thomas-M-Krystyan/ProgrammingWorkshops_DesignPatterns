using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Second implementation using <seealso cref="HttpClient"/> resource injected through constructor.
    /// </summary>
    public sealed class BusinessLogic2 : IHttpClientHandler
    {
        private readonly HttpClient _httpClient;
        private readonly string _implementationName = nameof(BusinessLogic2);

        public BusinessLogic2()
        {
            this._httpClient = new HttpClient();
            this._implementationName += "_hardcoded";
        }

        // NOTE: The most preferable solution would be to use HttpContextFactory. Check ASP.NET Core documentation => https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0
        public BusinessLogic2(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._implementationName += "_injected";
        }

        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse()
        {
            var result = await this._httpClient.GetAsync("http://webcode.me");

            return result.StatusCode;
        }

        /// <inheritdoc />
        public int GetClientId()
        {
            return this._httpClient.GetHashCode();
        }

        /// <inheritdoc />
        public string GetImplementationName()
        {
            return this._implementationName;
        }
    }
}
