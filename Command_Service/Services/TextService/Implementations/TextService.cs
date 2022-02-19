using Command_Service.Commands.Enums;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Services.TextService.Implementations
{
    /// <inheritdoc />
    /// <seealso cref="ITextService"/>
    public sealed class TextService : ITextService
    {
        private ColorsEnum _foreground;
        private ColorsEnum _bacgkround;
        private int _weight;

        /// <inheritdoc />
        public string ChangeForeground(ColorsEnum color)
        {
            this._foreground = color;

            return GetStyle();
        }

        /// <inheritdoc />
        public string ChangeBackground(ColorsEnum color)
        {
            this._bacgkround = color;

            return GetStyle();
        }

        /// <inheritdoc />
        public string ChangeWeight(bool isBold)
        {
            this._weight = isBold ? 500 : 0;

            return GetStyle();
        }

        /// <summary>
        /// Gets the valid style for HTML element.
        /// </summary>
        /// <returns>String containing all style information.</returns>
        private string GetStyle()
        {
            return $@"style=""color: {_foreground}; background-color: {_bacgkround}; font-weight: {_weight}""";
        }
    }
}
