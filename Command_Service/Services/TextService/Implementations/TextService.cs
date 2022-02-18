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
        public string ChangeWeight()
        {
            return $@"style=""font-weight: 500""";
        }

        /// <inheritdoc />
        public string ChangeBackground(string color)
        {
            return $@"style=""background-color: {color}""";
        }
    }
}
