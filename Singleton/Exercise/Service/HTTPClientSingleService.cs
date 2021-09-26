using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Exercise.Service
{
    public class HTTPClientSingleService
    {
        private HTTPClientSingleService() { }
        private static HttpClient _httpClient;
        private static readonly object padlock = new object();
        public static HttpClient GetInstance()
        {
            lock (padlock)
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient()
                    {
                    };
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
