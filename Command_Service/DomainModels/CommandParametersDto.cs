using Command_Service.Commands.Enums;
using System.ComponentModel.DataAnnotations;

namespace Command_Service.DomainModels
{
    public sealed class CommandParametersDto
    {
        /// <summary>
        /// Used to change text foreground color.
        /// </summary>
        [Required]
        public ForegroundColorsEnum ForegroundColor { get; set; }

        /// <summary>
        /// Used to change text background color.
        /// </summary>
        [Required]
        public BackgroundColorsEnum BackgroundColor { get; set; }

        /// <summary>
        /// Used to change the font weight.
        /// </summary>
        [Required]
        public bool IsFontBold { get; set; }

        /// <summary>
        /// Gets or sets the text to be formatted.
        /// </summary>
        public string Text { get; set; }
    }
}
