﻿using System.ComponentModel.DataAnnotations;
using Command_Service.Commands;
using Command_Service.Commands.Implementations;

namespace Command_Web.DTOs
{
    public class CommandDto
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
