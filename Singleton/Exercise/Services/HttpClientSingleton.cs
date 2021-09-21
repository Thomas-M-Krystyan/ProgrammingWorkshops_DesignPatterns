using System;
using System.Net.Http;

namespace Singleton.Exercise.Services
{
    public static class HttpClientSingleton
    {
        private static HttpClient _httpClient;
        private static readonly object Padlock = new();

        /// <summary>
        /// Singleton pattern to reuse the same HTTP Client and do not open new sockets.
        /// </summary>
        /// <remarks>
        ///   However, this solution does not support DNS or network-level changes.
        /// </remarks>
        /// <returns>A concrete instance of <see cref="HttpClient"/>.</returns>
        public static HttpClient GetClient()
        {
            lock (Padlock)
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient()
                    {
                        Timeout = TimeSpan.FromSeconds(new Random().Next(10, 61))  // NOTE: Generate random timeout to ensure that instances differentiate somehow
                    };
                }

                return _httpClient;
            }
        }

        public static void Dispose()
        {
            /* NOTE: If connection is not used or disposed, the sockets would be closed
                     on our end after reaching timeout (the default or custom one) */

            _httpClient?.Dispose();
        }
    }
}
