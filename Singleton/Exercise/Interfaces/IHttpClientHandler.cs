using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Interfaces
{
    public interface IHttpClientHandler
    {
        /// <summary>
        /// Returns the response from a simple Http call.
        /// </summary>
        /// <returns>HTTP status code.</returns>
        Task<HttpStatusCode> GetResponse(string requestUri);

        /// <summary>
        /// Gets the Http Client identifier.
        /// </summary>
        /// <returns>Client ID.</returns>
        HttpClient GetClient();

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <returns>Class name.</returns>
        string GetImplementationName();
    }
}
