using API.Commands.Interfaces;
using Implementation.Commands;
using NUnit.Framework;

namespace CommandTests
{
    [TestFixture]
    public class ChangeColorCommandTests
    {
        private ICommand _command;

        [SetUp]
        public void Setup()
        {
            this._command = new ChangeColorCommand();
        }

        [TestCase(ColorsEnum.Black, "black")]
        [TestCase(ColorsEnum.White, "white")]
        [TestCase(ColorsEnum.Red, "red")]
        [TestCase(ColorsEnum.Yellow, "yellow")]
        [TestCase(ColorsEnum.Green, "green")]
        public void Method_Execute_ForWeb_WithGivenParameter_ReturnsExpectedStyle(ColorsEnum color, string expectedColor)
        {
            // Act
            string result = this._command.Execute(color);

            // Assert
            Assert.That(result, Is.EqualTo($"style=\"color: {expectedColor}\""));
        }

        [Test]
        public void Method_Execute_ForWeb_WithoutParameter_ReturnsDefaultStyle()
        {
            // Act
            string result = this._command.Execute<ColorsEnum>();

            // Assert
            Assert.That(result, Is.EqualTo($"style=\"color: {default(ColorsEnum).ToString().ToLower()}\""));
        }
    }
}
