using System;
using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Interfaces;

namespace Command_Service.Commands.Implementations
{
    /// <summary>
    /// The available text colors.
    /// </summary>
    public enum ColorsEnum
    {
        // Default
        Black,

        // Additional
        White,
        Red,
        Yellow,
        Green
    }
    
    /// <summary>
    /// Command changing color of the text.
    /// </summary>
    /// <seealso cref="ICommand{T}"/>
    public sealed class ChangeFontColorCommand<T> : ICommand<T> where T : struct, Enum
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
        public string Execute(T color)
        {
            return this._textService.ChangeColor(color.ToString().ToLower());
        }
    }
}
