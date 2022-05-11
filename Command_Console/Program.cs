using System;
using Command_Service.Commands.Enums;
using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.Constants;
using Command_Service.DomainModels;
using Command_Service.Services.TextService.Implementations;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Console
{
    public static class Program
    {
        private static void Main()
        {
            ITextService consoleTextService = new ConsoleTextService();
            ICommand consoleFontStyleCommand = new FontStyleCommand(consoleTextService);
            
            // -------------------------------------------------------------------------
            // First example:
            var styleParameters = new CommandParametersDto
            {
                ForegroundColor = ForegroundColorsEnum.Yellow,
                BackgroundColor = BackgroundColorsEnum.Black,
                IsFontBold = true,
                Text = Utilities.Text
            };

            var formattedText = consoleFontStyleCommand.Execute(styleParameters);

            Console.WriteLine(formattedText);

            // -------------------------------------------------------------------------
            // Second example:
            styleParameters = new CommandParametersDto
            {
                ForegroundColor = ForegroundColorsEnum.Yellow,
                BackgroundColor = BackgroundColorsEnum.Black,
                IsFontBold = false,
                Text = Utilities.Text
            };

            formattedText = consoleFontStyleCommand.Execute(styleParameters);

            Console.WriteLine(formattedText);

            // -------------------------------------------------------------------------
            // Third example:
            styleParameters = new CommandParametersDto
            {
                ForegroundColor = ForegroundColorsEnum.White,
                BackgroundColor = BackgroundColorsEnum.Black,
                IsFontBold = true,
                Text = Utilities.Text
            };

            formattedText = consoleFontStyleCommand.Execute(styleParameters);

            Console.WriteLine(formattedText);

            // -------------------------------------------------------------------------
            // Fourth example:
            styleParameters = new CommandParametersDto
            {
                ForegroundColor = ForegroundColorsEnum.White,
                BackgroundColor = BackgroundColorsEnum.Black,
                IsFontBold = false,
                Text = Utilities.Text
            };

            formattedText = consoleFontStyleCommand.Execute(styleParameters);

            Console.WriteLine(formattedText);
            // -------------------------------------------------------------------------
        }
    }
}
