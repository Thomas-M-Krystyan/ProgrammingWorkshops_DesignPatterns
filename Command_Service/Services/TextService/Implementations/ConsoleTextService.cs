using Command_Service.Commands.Enums;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Services.TextService.Implementations
{
    /// <inheritdoc />
    /// <seealso cref="ITextService"/>
    public sealed class ConsoleTextService : ITextService
    {
        private const string Escape = @"[0m";

        /// <summary>
        /// Gets the valid style for text in console.
        /// </summary>
        public string GetStyle(ForegroundColorsEnum foregroundColor, BackgroundColorsEnum backgroundColor, bool isFontBold, string text)
        {
            var formattedText = isFontBold ? GetFontBold(text) : text;

            formattedText = GetForegroundColor(foregroundColor, formattedText);
            formattedText = GetBackgroundColor(backgroundColor, formattedText);

            return formattedText;
        }

        private static string GetFontBold(string text)
        {
            return @$"[1m{text}{Escape}";
        }

        private static string GetForegroundColor(ForegroundColorsEnum foregroundColor, string text)
        {
            var opening = foregroundColor switch
            {
                ForegroundColorsEnum.Black  => @"[30m",
                ForegroundColorsEnum.White  => @"[37m",
                ForegroundColorsEnum.Red    => @"[31m",
                ForegroundColorsEnum.Yellow => @"[33m",
                ForegroundColorsEnum.Green  => @"[32m",
                ForegroundColorsEnum.Blue   => @"[34m",
                ForegroundColorsEnum.Purple => @"[35m",
                _ => @"[30m"  // Default black
            };

            return @$"{opening}{text}{Escape}";
        }

        private static string GetBackgroundColor(BackgroundColorsEnum backgroundColor, string text)
        {
            var opening = backgroundColor switch
            {
                BackgroundColorsEnum.White  => @"[47m",
                BackgroundColorsEnum.Black  => @"[40m",
                BackgroundColorsEnum.Red    => @"[41m",
                BackgroundColorsEnum.Yellow => @"[43m",
                BackgroundColorsEnum.Green  => @"[42m",
                BackgroundColorsEnum.Blue   => @"[44m",
                BackgroundColorsEnum.Purple => @"[45m",
                _ => @"[47m"  // Default white
            };

            return @$"{opening}{text}{Escape}";
        }
    }
}
