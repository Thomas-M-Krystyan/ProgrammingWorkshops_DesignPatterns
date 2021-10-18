using Microsoft.Extensions.Logging;
using Singleton.Exercise.Interfaces;
using Singleton.Exercise.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Singleton.Exercise.Implementations
{
    /// <summary>
    /// First implementation using <seealso cref="HttpClient"/> resource as a readonly, class-scope initialized field.
    /// </summary>
    public sealed class BusinessLogic1 : HttpClientHandlerAbstract
    {
        public BusinessLogic1(ILogger logger) : base (logger)
        {

        }
        public override string GetImplementationName()
        {
            return nameof(BusinessLogic1);
        }
     
    }
}
