using System;
using Facade.Facade;
using Facade.Services.Displays;
using Facade.Services.Mathematics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace FacadeTests.Services
{
    [TestFixture]
    public class RichCalculationFacadeTest
    {
        //[TestCase(null, "Happy !")]  // Value is empty
        [TestCase(new double[] { 4.0, 8.0, 15.0, 16.0, 23.0, 42.0 }, "Happy 2021.9999999999995!")]    // Value is empty
        public void Method_Enrich_ReturnsFormattedText(double[] value, string expectedResult)
        {
            // Arrange
            var richCalculationlogger = new NullLogger<RichCalculationFacade>();
            var addingServicelogger = new NullLogger<AddingService>();
            var multiplyServicelogger = new NullLogger<MultiplyingService>();
            var adddingService = new AddingService(addingServicelogger);
            var multiplyService = new MultiplyingService(multiplyServicelogger);
            var displayService = new RichTextService();
            var service = new RichCalculationFacade(richCalculationlogger,adddingService,multiplyService,displayService);

            // Act
            var actualResult = service.PrepareResult(value);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
