using Command_Service.Commands.Enums;
using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Interfaces;
using System;

namespace Command_Service.Subscriber
{
    /// <summary>
    /// The class responsible for establishing an application context (e.g., web or console) and
    /// keeping consistency regarding which commands and methods will be used for a given context.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class CommandsSubscriber : IDisposable
    {
        // Service
        private readonly ITextService _textService;

        // Commands
        private ICommand<ColorsEnum> _fontColorCommand;
        private ICommand<ColorsEnum> _backgroundCommand;
        private ICommand<bool> _weightCommand;

        // Delegates
        public Func<ColorsEnum, string> OnFontColorChange;
        public Func<ColorsEnum, string> OnFontBackgroundColorChange;
        public Func<bool, string> OnFontWeightChange;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandsSubscriber"/> class.
        /// </summary>
        /// <param name="textService">The text service.</param>
        public CommandsSubscriber(ITextService textService)
        {
            this._textService = textService;

            InitializeCommands();
            SubscribeCommands();
        }

        /// <summary>
        /// Initializes the specific commands.
        /// </summary>
        private void InitializeCommands()
        {
            this._fontColorCommand = new ChangeFontColorCommand<ColorsEnum>(this._textService);
            this._backgroundCommand = new ChangeTextBackgroundCommand<ColorsEnum>(this._textService);
            this._weightCommand = new ChangeFontWeightCommand(this._textService);
        }

        /// <summary>
        /// Subscribes commands-related delegates.
        /// </summary>
        private void SubscribeCommands()
        {
            OnFontColorChange += this._fontColorCommand.Execute;
            OnFontBackgroundColorChange += this._backgroundCommand.Execute;
            OnFontWeightChange += this._weightCommand.Execute;
        }

        /// <summary>
        /// Unsubscribes command-related delegates.
        /// </summary>
        public void Dispose()
        {
            OnFontColorChange = null;
            OnFontBackgroundColorChange = null;
            OnFontWeightChange = null;
        }
    }
}
