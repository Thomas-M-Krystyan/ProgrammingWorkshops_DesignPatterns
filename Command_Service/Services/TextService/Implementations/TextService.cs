using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Services.TextService.Implementations
{
    /// <inheritdoc />
    /// <seealso cref="ITextService"/>
    public sealed class TextService : ITextService
    {
        /// <inheritdoc />
        public string ChangeColor(string color)
        {
            return $@"style=""color: {color}""";
        }

        /// <inheritdoc />
        public string ChangeWeight(bool isBold)
        {
            return $@"style=""font-weight: {(isBold ? 500 : 0)}""";
        }

        /// <inheritdoc />
        public string ChangeBackground(string color)
        {
            return $@"style=""background-color: {color}""";
        }
    }
}
