using System.Net.Http;

namespace Singleton.Exercise.Services
{
    public class HttpClientSingleton : IRepository
    {
        private static HttpClient _httpClient;
        private static readonly object Padlock = new();

        private HttpClientSingleton() { }

        /// <summary>
        /// Singleton pattern to reuse the same HTTP Client.
        /// </summary>
        /// <returns>A concrete instance of HttpClient.</returns>
        public static HttpClient GetClient()
        {
            lock (Padlock)
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }

                return _httpClient;
            }
        }

        public static void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
