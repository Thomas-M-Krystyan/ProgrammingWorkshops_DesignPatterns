using Command_Service.Commands;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Services.TextService.Implementations
{
    /// <inheritdoc />
    /// <seealso cref="ITextService"/>
    public sealed class TextService : ITextService
    {
        /// <inheritdoc />
        public string GetStyle(ForegroundColorsEnum foregroundColor, BackgroundColorsEnum backgroundColor, bool isFontBold)
        {
            return $@"style=""color: {foregroundColor}; background-color: {backgroundColor}; font-weight: {(isFontBold ? 500 : 0)}""";
        }
    }
}
