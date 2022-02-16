using Command_Service.API.Commands;

namespace Command_Service.Implementation.Commands
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
    /// <seealso cref="ICommand" />
    public class ChangeColorCommand : ICommand
    {
        /// <inheritdoc />
        public string Execute<ColorsEnum>(ColorsEnum color)
        {
            return $@"style=""color: {color.ToString()?.ToLower()}""";
        }
    }
}
