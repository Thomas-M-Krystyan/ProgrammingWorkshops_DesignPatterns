using Singleton.Exercise.Implementations.Abstractions;
using System.Net.Http;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Third implementation using <seealso cref="HttpClient"/>.
    /// </summary>
    public sealed class BusinessLogic3 : BaseHttpClientHandler
    {
        /// <inheritdoc />
        public BusinessLogic3(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic3);
        }
    }
}
