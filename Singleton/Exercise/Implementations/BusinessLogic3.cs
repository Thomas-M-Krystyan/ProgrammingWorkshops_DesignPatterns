using Singleton.Exercise.Interfaces;
using System.Net;
using System.Net.Http;
using Singleton.Exercise.Service;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// Third implementation using <seealso cref="System.Net.Http.HttpClient"/> resource injected through property.
    /// </summary>
    public sealed class BusinessLogic3 : HttpClientHandlerAbstract
    {
        public BusinessLogic3(ILogger logger) : base(logger)
        {

        }
        /// <inheritdoc />
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic3);
        }
    }
}
