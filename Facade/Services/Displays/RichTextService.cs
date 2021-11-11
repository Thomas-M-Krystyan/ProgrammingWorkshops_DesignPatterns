using Facade.Services.Displays.Interfaces;

namespace Facade.Services.Displays
{
    /// <summary>
    /// Formats the original calculation result for display purposes.
    /// </summary>
    /// <seealso cref="IDisplay" />
    public sealed class RichTextService : IDisplay
    {
        /// <inheritdoc />
        public string Enrich(object value)
        {
            return @$"The result is: {value}";
        }
    }
}
