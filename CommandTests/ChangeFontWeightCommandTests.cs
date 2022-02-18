using Command_Service.Commands.Implementations;
using Command_Service.Commands.Interfaces;
using Command_Service.Services.TextService.Implementations;
using NUnit.Framework;

namespace CommandTests
{
    [TestFixture]
    public class ChangeFontWeightCommandTests
    {
        private ICommand<bool> _command;
        
        [SetUp]
        public void Setup()
        {
            this._command = new ChangeFontWeightCommand(new TextService());
        }
        
        [TestCase(true, 500)]
        [TestCase(false, 0)]
        public void Method_Execute_ForWeb_WithGivenParameter_ReturnsExpectedStyle(bool isBold, int weight)
        {
            // Act
            string result = this._command.Execute(isBold);

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""font-weight: {weight}"""));
        }

        [Test]
        public void Method_Execute_ForWeb_WithoutParameter_ReturnsDefaultStyle()
        {
            // Act
            string result = this._command.Execute();

            // Assert
            Assert.That(result, Is.EqualTo($@"style=""font-weight: 0"""));
        }
    }
}
