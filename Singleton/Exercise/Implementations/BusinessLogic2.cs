using Microsoft.Extensions.Logging;
using Singleton.Exercise.Implementations.Abstractions;
using System.Net.Http;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Second implementation using <seealso cref="HttpClient"/>.
    /// </summary>
    public sealed class BusinessLogic2 : BaseHttpClientHandler
    {
        /// <inheritdoc />
        public BusinessLogic2(ILogger<BaseHttpClientHandler> logger, IHttpClientFactory clientFactory) : base(logger, clientFactory)
        {
        }

        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic2);
        }
    }
}
