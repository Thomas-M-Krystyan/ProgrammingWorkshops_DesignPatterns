using Facade.Services.Displays;
using NUnit.Framework;
using System.Threading.Tasks;

namespace FacadeTests.Services
{
    [TestFixture]
    public class RichTextServiceTests
    {
        private const string NewYearResult = "Happy ";
        private const string StandardResult = "The result is: ";

        [TestCase(null, NewYearResult + "!")]  // Value is empty
        [TestCase("", NewYearResult + "!")]    // Value is empty
        [TestCase("25", NewYearResult + "25!")]
        [TestCase(new object[] { }, NewYearResult + "System.Object[]!")]
        public async Task Method_Enrich_ForNewYearMode_ReturnsFormattedText(object value, string expectedResult)
        {
            // Arrange
            RichTextService service = new();

            // Act
            string actualResult = await service.Enrich(value, DisplayModeEnums.WelcomeNewYear);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(null, StandardResult + "")]  // Value is empty
        [TestCase("", StandardResult + "")]    // Value is empty
        [TestCase("25", StandardResult + "25")]
        [TestCase(new object[] { }, StandardResult + "System.Object[]")]
        public async Task Method_Enrich_ForStandardMode_ReturnsFormattedText(object value, string expectedResult)
        {
            // Arrange
            RichTextService service = new();

            // Act
            string actualResult = await service.Enrich(value, DisplayModeEnums.Standard);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
