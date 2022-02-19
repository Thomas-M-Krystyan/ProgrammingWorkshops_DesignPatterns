using Command_Service.Commands.Enums;

namespace Command_Service.Services.TextService.Interfaces
{
    /// <summary>
    /// Interface changing text properties (the way how it is formatted and/or displayed).
    /// </summary>
    public interface ITextService
    {
        /// <summary>
        /// Changes the text foreground color.
        /// </summary>
        /// <param name="color">The desired font color.</param>
        /// <returns>The output format.</returns>
        string ChangeForeground(ColorsEnum color);

        /// <summary>
        /// Changes the text background color.
        /// </summary>
        /// <param name="color">The desired background color.</param>
        /// <returns>The output format.</returns>
        string ChangeBackground(ColorsEnum color);

        /// <summary>
        /// Changes the text weight.
        /// </summary>
        /// <param name="isBold">Determine whether the font should be changed to bold or reset to normal.</param>
        /// <returns>The output format.</returns>
        string ChangeWeight(bool isBold);
    }
}
