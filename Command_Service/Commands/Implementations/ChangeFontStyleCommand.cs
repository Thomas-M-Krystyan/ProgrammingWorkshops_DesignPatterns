using System;
using System.Windows.Input;
using Command_Service.Services.TextService.Interfaces;
using Command_Service.Commands.Interfaces;
using ICommand = Command_Service.Commands.Interfaces.ICommand;

namespace Command_Service.Commands.Implementations
{
    public class ChangeFontStyleCommand : ICommand
    {
        private readonly ITextService _textService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FontStyleCommand"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public ChangeFontStyleCommand(ITextService textService)
        {
            this._textService = textService;
        }

        /// <inheritdoc />
        public string Execute(CommandParametersDto dto)
        {
            return this._textService.GetStyle(dto.ForegroundColor, dto.BackgroundColor, dto.IsFontBold);
        }

    }
}
