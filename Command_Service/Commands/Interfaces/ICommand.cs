using Command_Service.DomainModels;

namespace Command_Service.Commands.Interfaces
{
    /// <summary>
    /// The interface for all commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes a specific logic of a command.
        /// </summary>
        /// <param name="parameters">The parameters to be used along with a command.</param>
        /// <returns>The text result of a command execution.</returns>
        string Execute(CommandParametersDto parameters);
    }
}
