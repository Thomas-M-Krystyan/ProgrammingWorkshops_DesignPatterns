using Singleton.Exercise.Interfaces;
using Singleton.Exercise.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// First implementation using <seealso cref="HttpClient"/> resource as a readonly, class-scope initialized field.
    /// </summary>
    public sealed class BusinessLogic1 : IHttpClientHandler
    {
        private readonly HttpClient _httpClient = HTTPClientSingleService.GetInstance();  // NOTE: New C# 9.0 syntax, to not write obvious "new HttpClient()" => https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9

        /// <inheritdoc />
        public async Task<HttpStatusCode> GetResponse()
        {
            try
            {
                var result = await this._httpClient.GetAsync("http://webcode.me");

                return result.StatusCode;
            }
            catch(Exception ex)
            {
                return HttpStatusCode.ExpectationFailed;
            }

        }

        /// <inheritdoc />
        public int GetClientId()
        {
            /* NOTE: "GetHashCode" does not guarantee in 100% that the id will be unique, but this is a simple
             * solution to give us a fast result. Check "ObjectIDGenerator.GetId" solution for further details */

            return this._httpClient.GetHashCode();
        }

        /// <inheritdoc />
        public string GetImplementationName()
        {
            return nameof(BusinessLogic1);
        }
    }
}
