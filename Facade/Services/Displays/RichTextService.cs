using Facade.Services.Displays.Interfaces;

namespace Facade.Services.Displays
{
    /// <summary>
    /// The specific display modes.
    /// </summary>
    public enum DisplayModeEnums
    {
        Standard,
        WelcomeNewYear
    }

    /// <summary>
    /// Formats the original calculation result for display purposes.
    /// </summary>
    /// <seealso cref="IDisplay" />
    public sealed class RichTextService : IDisplay
    {
        /// <inheritdoc />
        public string Enrich(object value, DisplayModeEnums mode)
        {
            switch (mode)
            {
                case DisplayModeEnums.WelcomeNewYear:
                    return @$"Happy {value}!";

                case DisplayModeEnums.Standard:
                default:
                    return @$"<strong>The result is:</strong> {value}";
            }
        }
    }
}
