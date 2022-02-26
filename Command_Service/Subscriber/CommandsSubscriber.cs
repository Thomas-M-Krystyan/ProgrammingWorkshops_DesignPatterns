using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.DomainModels;
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
        private ICommand _fontStyleCommand;

        // Delegates
        public Func<CommandParametersDto, string> OnFontStyleUpdate;

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
            this._fontStyleCommand = new FontStyleCommand(this._textService);
        }

        /// <summary>
        /// Subscribes commands-related delegates.
        /// </summary>
        private void SubscribeCommands()
        {
            OnFontStyleUpdate += this._fontStyleCommand.Execute;
        }

        /// <summary>
        /// Unsubscribes command-related delegates.
        /// </summary>
        public void Dispose()
        {
            OnFontStyleUpdate = null;
        }
    }
}
