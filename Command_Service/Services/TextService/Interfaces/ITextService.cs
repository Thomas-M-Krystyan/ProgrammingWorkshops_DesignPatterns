using Command_Service.Commands.Enums;

namespace Command_Service.Services.TextService.Interfaces
{
    /// <summary>
    /// Interface changing text properties (the way how it is formatted and/or displayed).
    /// </summary>
    public interface ITextService
    {
        /// <summary>
        /// Gets the valid text style.
        /// </summary>
        /// <param name="foregroundColor">The desired font color.</param>
        /// <param name="backgroundColor">The desired background color.</param>
        /// <param name="isFontBold">Determine whether the font should be changed to bold or reset to normal.</param>
        /// <param name="text">An optional text to be changed.</param>
        /// <returns>The output format.</returns>
        string GetStyle(ForegroundColorsEnum foregroundColor, BackgroundColorsEnum backgroundColor, bool isFontBold, string text = default);
    }
}
