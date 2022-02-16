namespace Command_Service.API.Commands
{
    /// <summary>
    /// The interface for all commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes a specific logic of a command.
        /// </summary>
        /// <typeparam name="T">The type of generic parameter.</typeparam>
        /// <param name="parameter">The generic parameter to be used along with a command.</param>
        /// <returns>The text result of a command execution.</returns>
        string Execute<T>(T parameter = default);
    }
}
