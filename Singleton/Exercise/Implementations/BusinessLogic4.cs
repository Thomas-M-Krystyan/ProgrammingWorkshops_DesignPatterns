using Microsoft.Extensions.Logging;
using Singleton.Exercise.Implementations.Abstractions;
using System.Net.Http;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Fourth implementation using <seealso cref="HttpClient"/>.
    /// </summary>
    public sealed class BusinessLogic4 : BaseHttpClientHandler
    {
        /// <inheritdoc />
        public BusinessLogic4(ILogger<BaseHttpClientHandler> logger, IHttpClientFactory clientFactory) : base(logger, clientFactory)
        {
        }

        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic4);
        }
    }
}
