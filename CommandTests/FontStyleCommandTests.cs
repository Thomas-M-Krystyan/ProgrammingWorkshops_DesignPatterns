using Command_Service.Commands.Enums;
using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.DomainModels;
using Command_Service.Services.TextService.Implementations;
using NUnit.Framework;
using System;
using System.Linq;

namespace CommandTests
{
    [TestFixture]
    public class FontStyleCommandTests
    {
        private ICommand _command;
        
        [SetUp]
        public void Setup()
        {
            this._command = new FontStyleCommand(new TextService());
        }

        [TestCaseSource(nameof(GetForegroundEnums))]
        public void Method_Execute_ForWeb_WithGivenForegroundColor_ReturnsExpectedStyle((ForegroundColorsEnum ForegroundColor, string Name) enums)
        {
            // Arrange
            CommandParametersDto dto = new()
            {
                ForegroundColor = enums.ForegroundColor,
                BackgroundColor = default,
                IsFontBold = default
            };

            // Act
            string result = this._command.Execute(dto);

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""color: {enums.Name}; background-color: White; font-weight: 0"""));
        }

        [TestCaseSource(nameof(GetBackgroundEnums))]
        public void Method_Execute_ForWeb_WithGivenBackgroundColor_ReturnsExpectedStyle((BackgroundColorsEnum BackgroundColor, string Name) enums)
        {
            // Arrange
            CommandParametersDto dto = new()
            {
                ForegroundColor = default,
                BackgroundColor = enums.BackgroundColor,
                IsFontBold = default
            };

            // Act
            string result = this._command.Execute(dto);

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""color: Black; background-color: {enums.Name}; font-weight: 0"""));
        }

        [TestCase(true, 500)]
        [TestCase(false, 0)]
        public void Method_Execute_ForWeb_WithGivenFontWeight_ReturnsExpectedStyle(bool isFontWeight, int weight)
        {
            // Arrange
            CommandParametersDto dto = new()
            {
                ForegroundColor = default,
                BackgroundColor = default,
                IsFontBold = isFontWeight
            };

            // Act
            string result = this._command.Execute(dto);

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""color: Black; background-color: White; font-weight: {weight}"""));
        }

        private static (ForegroundColorsEnum, string)[] GetForegroundEnums() => GetEnumsWithNames<ForegroundColorsEnum>();

        private static (BackgroundColorsEnum, string)[] GetBackgroundEnums() => GetEnumsWithNames<BackgroundColorsEnum>();

        private static (T, string)[] GetEnumsWithNames<T>()
        {
            return ((T[])Enum.GetValues(typeof(T)))             // Get all enums of specified type
                .Select(option => (option, option.ToString()))  // Convert enums to a tuple of (enum + enum's name)
                .ToArray();
        }
    }
}
