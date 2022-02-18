using Command_Service.Commands.Enums;
using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Implementations;
using NUnit.Framework;
using System;
using System.Linq;

namespace CommandTests
{
    [TestFixture]
    public class ChangeBackgroundColorCommandTests
    {
        private ICommand<ColorsEnum> _command;
        
        [SetUp]
        public void Setup()
        {
            this._command = new ChangeTextBackgroundCommand<ColorsEnum>(new TextService());
        }

        [TestCaseSource(nameof(GetEnumsWithNames))]
        public void Method_Execute_ForWeb_WithGivenParameter_ReturnsExpectedStyle((ColorsEnum Color, string Name) enums)
        {
            // Act
            string result = this._command.Execute(enums.Color);

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""background-color: {enums.Name}"""));
        }

        [Test]
        public void Method_Execute_ForWeb_WithoutParameter_ReturnsDefaultStyle()
        {
            // Act
            string result = this._command.Execute();

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""background-color: {default(ColorsEnum).ToString().ToLower()}"""));
        }

        private static (ColorsEnum, string)[] GetEnumsWithNames()
        {
            return ((ColorsEnum[])Enum.GetValues(typeof(ColorsEnum)))     // Get all enums of specified type
                .Select(option => (option, option.ToString().ToLower()))  // Convert enums to a tuple of (enum + enum's name as lower case)
                .ToArray();
        }
    }
}
