namespace Command_Service.Commands.Interfaces
{
    /// <summary>
    /// The interface for all commands.
    /// </summary>
    /// <typeparam name="T">The type of generic parameter.</typeparam>
    public interface ICommand
    {
        /// <summary>
        /// Executes a specific logic of a command.
        /// </summary>
        /// <param name="parameter">The generic parameter to be used along with a command.</param>
        /// <returns>The text result of a command execution.</returns>
        string Execute(CommandParametersDto parametersDto);
    }
}
