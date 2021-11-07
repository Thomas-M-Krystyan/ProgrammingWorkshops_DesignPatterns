using NUnit.Framework;
using Strategy.Exercise.TraverseStrategies;
using System;

namespace StrategyTests
{
    [TestFixture]
    public class BFS_StrategyTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void FindElementA(bool isLeftHanded)
        {
            // Act
            var result = GetBfsStrategy(isLeftHanded).Find("A");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsFound);
            Assert.That(result.Path, Is.EqualTo("A"));
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [TestCase(true, "ABCDE", 5)]
        [TestCase(false, "ACBFE", 5)]
        public void FindElementE(bool isLeftHanded, string path, int count)
        {
            // Act
            var result = GetBfsStrategy(isLeftHanded).Find("E");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsFound);
            Assert.That(result.Path, Is.EqualTo(path));
            Assert.That(result.Count, Is.EqualTo((ushort)count));
        }

        [TestCase(true, null)]
        [TestCase(true, "")]
        [TestCase(true, " ")]
        [TestCase(true, "Z")]
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, " ")]
        [TestCase(false, "Z")]
        public void FindElement_ForNotExistingValue_ReturnsEmptyResult(bool isLeftHanded, string value)
        {
            // Act
            var result = GetBfsStrategy(isLeftHanded).Find(value);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsFound);
            Assert.That(result.Path, Is.EqualTo(String.Empty));
            Assert.That(result.Count, Is.EqualTo(0));
        }

        private static BFS_Strategy GetBfsStrategy(bool isLeftHanded)
        {
            return new(isLeftHanded);
        }
    }
}
