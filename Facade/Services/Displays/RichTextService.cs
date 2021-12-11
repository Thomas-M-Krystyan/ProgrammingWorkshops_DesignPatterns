using Facade.Services.Displays.Interfaces;
using System.Threading.Tasks;

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
        public async Task<string> Enrich(object value, DisplayModeEnums mode)
        {
            return await Task.Run(() =>
            {
                return mode switch
                {
                    DisplayModeEnums.WelcomeNewYear => @$"Happy {value}!",

                    _ => @$"<strong>The result is:</strong> {value}",
                };
            });
        }
    }
}
