using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Interfaces;
using System;

namespace Command_Service.Commands.Implementations
{
    /// <summary>
    /// Command changing background of the text.
    /// </summary>
    /// <summary>
    /// <seealso cref="ICommand{T}"/>
    public sealed class ChangeTextBackgroundCommand<T> : ICommand<T> where T : struct, Enum
    {
        private readonly ITextService _textService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeTextBackgroundCommand{T}"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public ChangeTextBackgroundCommand(ITextService textService)
        {
            this._textService = textService;
        }

        /// <inheritdoc />
        public string Execute(T color)
        {
            return this._textService.ChangeBackground(color.ToString().ToLower());
        }
    }
}
