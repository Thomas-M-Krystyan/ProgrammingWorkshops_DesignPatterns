using Facade.Services.Displays;
using NUnit.Framework;

namespace FacadeTests.Services
{
    [TestFixture]
    public class RichTextServiceTests
    {
        private const string ResultText = "The result is: ";

        [TestCase(null, ResultText)]  // Value is empty
        [TestCase("", ResultText)]    // Value is empty
        [TestCase("25", ResultText + "25")]
        [TestCase(new object[] { }, ResultText + "System.Object[]")]
        public void Method_Enrich_ReturnsFormattedText(object value, string expectedResult)
        {
            // Arrange
            var service = new RichTextService();

            // Act
            var actualResult = service.Enrich(value);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
