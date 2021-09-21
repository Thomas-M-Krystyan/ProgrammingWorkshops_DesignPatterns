using Microsoft.Extensions.Logging;
using Singleton.Exercise.Implementations.Abstractions;
using System.Net.Http;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// First implementation using <seealso cref="HttpClient"/>.
    /// </summary>
    public sealed class BusinessLogic1 : BaseHttpClientHandler
    {
        /// <inheritdoc />
        public BusinessLogic1(ILogger<BaseHttpClientHandler> logger) : base(logger)
        {
        }

        /// <inheritdoc />
        public BusinessLogic1(ILogger<BaseHttpClientHandler> logger, IHttpClientFactory clientFactory) : base(logger, clientFactory)
        {
        }

        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic1);
        }
    }
}
