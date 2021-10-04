using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Singleton.Exercise.Service;
using Microsoft.Extensions.Logging;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Fourth implementation using <seealso cref="HttpClient"/> resource created internally on demand.
    /// </summary>
    public sealed class BusinessLogic4 : HttpClientHandlerAbstract
    {
        public BusinessLogic4(ILogger logger) : base(logger)
        {

        }
        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic4);
        }
    }
}
