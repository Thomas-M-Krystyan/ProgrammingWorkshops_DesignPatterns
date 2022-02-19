using Command_Service.Commands.Enums;
using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Commands.Implementations
{
    /// <summary>
    /// Command changing color of the text.
    /// </summary>
    /// <seealso cref="ICommand{T}"/>
    public sealed class ChangeFontColorCommand : ICommand<ColorsEnum>
    {
        private readonly ITextService _textService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFontColorCommand{T}"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public ChangeFontColorCommand(ITextService textService)
        {
            this._textService = textService;
        }

        /// <inheritdoc />
        public string Execute(ColorsEnum color)
        {
            return this._textService.ChangeForeground(color);
        }
    }
}
