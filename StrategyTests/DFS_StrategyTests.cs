using NUnit.Framework;
using Strategy.Exercise.TraverseStrategies;
using System;

namespace StrategyTests
{
    [TestFixture]
    public class DFS_StrategyTests
    {
        private DFS_Strategy _strategy;

        [SetUp]
        public void InitializeTests()
        {
            this._strategy = new();
        }

        [Test]
        public void FindElementA()
        {
            // Act
            var result = this._strategy.Find("A");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsFound);
            Assert.That(result.Path, Is.EqualTo("A"));
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void FindElementE()
        {
            // Act
            var result = this._strategy.Find("E");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsFound);
            Assert.That(result.Path, Is.EqualTo("ABDGCFE"));
            Assert.That(result.Count, Is.EqualTo(7));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Z")]
        public void FindElement_ForNotExistingValue_ReturnsEmptyResult(string value)
        {
            // Act
            var result = this._strategy.Find(value);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsFound);
            Assert.That(result.Path, Is.EqualTo(String.Empty));
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
