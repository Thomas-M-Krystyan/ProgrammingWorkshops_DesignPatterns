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
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public string ChangeBackground()
        {
            throw new System.NotImplementedException();
        }
    }
}
