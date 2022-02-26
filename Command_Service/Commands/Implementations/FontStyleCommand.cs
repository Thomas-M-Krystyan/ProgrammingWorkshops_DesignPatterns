using Command_Service.Commands.Interfaces;
using Command_Service.DomainModels;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Commands.Implementations
{
    /// <summary>
    /// Command changing font properties such as color, background or weight.
    /// </summary>
    /// <seealso cref="ICommand"/>
    public sealed class FontStyleCommand : ICommand
    {
        private readonly ITextService _textService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FontStyleCommand"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public FontStyleCommand(ITextService textService)
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
