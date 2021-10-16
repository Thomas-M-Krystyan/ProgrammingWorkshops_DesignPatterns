using NUnit.Framework;
using Strategy.Exercise.Data;

namespace StrategyTests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void GraphContains10Nodes()
        {
            Assert.That(Graph.Count, Is.EqualTo(10));
        }

        [Test]
        public void GraphFirstNodeIsA()
        {
            Assert.That(Graph.StartNode.Value, Is.EqualTo("A"));
        }
    }
}
