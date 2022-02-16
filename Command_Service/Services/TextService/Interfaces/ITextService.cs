namespace Command_Service.Services.TextService.Interfaces
{
    /// <summary>
    /// Interface changing text properties (the way how it is formatted and/or displayed).
    /// </summary>
    public interface ITextService
    {
        /// <summary>
        /// Changes the text color.
        /// </summary>
        /// <param name="color">The desired color.</param>
        /// <returns>The output format.</returns>
        string ChangeColor(string color);

        /// <summary>
        /// Changes the text weight.
        /// </summary>
        /// <returns>The output format.</returns>
        string ChangeWeight();

        /// <summary>
        /// Changes the text background.
        /// </summary>
        /// <returns>The output format.</returns>
        string ChangeBackground();
    }
}
