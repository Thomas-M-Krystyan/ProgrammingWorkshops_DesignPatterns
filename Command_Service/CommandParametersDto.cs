using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command_Service.Commands;

namespace Command_Service
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
    }
}
