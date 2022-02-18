using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Commands.Implementations
{
    /// <summary>
    /// Command changing weight (bold effect) of the text.
    /// </summary>
    public sealed class ChangeFontWeightCommand : ICommand<bool>
    {
        private readonly ITextService _textService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFontWeightCommand"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public ChangeFontWeightCommand(ITextService textService)
        {
            this._textService = textService;
        }

        /// <inheritdoc />
        public string Execute(bool isBold)
        {
            return this._textService.ChangeWeight(isBold);
        }
    }
}
