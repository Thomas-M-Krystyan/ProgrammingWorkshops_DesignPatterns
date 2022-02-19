using Command_Service.Commands.Enums;
using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Interfaces;
using System;

namespace Command_Service.Subscriber
{
    public sealed class CommandsSubscriber : IDisposable
    {
        // Service
        private readonly ITextService _textService;

        // Commands
        private ICommand<ColorsEnum> _fontColorCommand;
        private ICommand<ColorsEnum> _backgroundCommand;
        private ICommand<bool> _weightCommand;

        // Events
        public event Func<ColorsEnum, string> OnFontColorChange;
        public event Func<ColorsEnum, string> OnFontBackgroundColorChange;
        public event Func<bool, string> OnFontWeightChange;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandsSubscriber"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public CommandsSubscriber(ITextService textService)
        {
            this._textService = textService;
        }

        public void InitializeWebCommands()
        {
            this._fontColorCommand = new ChangeFontColorCommand<ColorsEnum>(this._textService);
            this._backgroundCommand = new ChangeTextBackgroundCommand<ColorsEnum>(this._textService);
            this._weightCommand = new ChangeFontWeightCommand(this._textService);

            Subscribe();
        }

        /// <summary>
        /// Subscribes events.
        /// </summary>
        private void Subscribe()
        {
            OnFontColorChange += this._fontColorCommand.Execute;
            OnFontBackgroundColorChange += this._backgroundCommand.Execute;
            OnFontWeightChange += this._weightCommand.Execute;
        }

        /// <summary>
        /// Disposes subscriber's events.
        /// </summary>
        public void Dispose()
        {
            OnFontColorChange = null;
            OnFontBackgroundColorChange = null;
            OnFontWeightChange = null;
        }
    }
}
