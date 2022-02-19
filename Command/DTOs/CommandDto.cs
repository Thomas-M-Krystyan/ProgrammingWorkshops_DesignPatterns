using Command_Service.Commands.Enums;

namespace Command_Web.DTOs
{
    /// <summary>
    /// The DTO model used to pass user input from the main view.
    /// </summary>
    public class CommandDto
    {
        /// <summary>
        /// Used to change text foreground color.
        /// </summary>
        public ColorsEnum ForegroundColor { get; set; }

        /// <summary>
        /// Used to change text background color.
        /// </summary>
        public ColorsEnum BackgroundColor { get; set; }

        /// <summary>
        /// Used to change the font weight.
        /// </summary>
        public bool IsBold { get; set; }
    }
}
