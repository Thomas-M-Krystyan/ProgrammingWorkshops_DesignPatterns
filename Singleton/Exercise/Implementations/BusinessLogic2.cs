using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Singleton.Exercise.Service;
using Microsoft.Extensions.Logging;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Second implementation using <seealso cref="HttpClient"/> resource injected through constructor.
    /// </summary>
    public sealed class BusinessLogic2 : HttpClientHandlerAbstract
    {

        public BusinessLogic2(ILogger logger) : base(logger)
        {

        }
        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic2);
        }
    }
}
