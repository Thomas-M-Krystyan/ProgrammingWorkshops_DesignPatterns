using Iterator.Exercise.Data;
using NUnit.Framework;

namespace IteratorTests
{
    public class BfsIteratorTests
    {
        private const int GraphSize = 30;
        private BfsIterator _iterator;

        [SetUp]
        public void Setup()
        {
            // NOTE: This is not the place to test whether graph is created properly. You need to
            // test functionality of this class separately, in a separate GraphIteratorTests.cs file

            Graph graph = new Graph(GraphSize);  // HINT: Method to initialize the graph can be private

            this._iterator = new BfsIterator(graph, isLeftHanded: true);
        }

        [Test]
        public void CheckIfBfsIterator_CanBeIterated()
        {
            // Act
            int count = 0;

            foreach (Node _ in this._iterator)
            {
                count++;
            }

            // Assert
            Assert.True(count == GraphSize);
        }

        [Test]
        public void CheckIfMethod_Count_ReturnsNumberOfGraphNodes()
        {
            // Assert
            Assert.True(this._iterator.Count == GraphSize);
        }

        // -----------------
        // Extension methods
        // -----------------

        [TestCase("K", true)]
        [TestCase("AC", false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(null, false)]
        public void CheckIfMethod_Find_ReturnsProperSearchResult(string nodeValue, bool canBeFound)
        {
            // Act
            bool isFound = this._iterator.Find(nodeValue);

            // Assert
            Assert.True(isFound == canBeFound);
        }

        [Test]
        public void CheckIfMethod_First_ReturnsFirstNode()
        {
            // Act
            Node firstNode = this._iterator.First();

            // Assert
            Assert.That(firstNode.Value, Is.EqualTo("A"));
        }

        [Test]
        public void CheckIfMethod_Last_ReturnsLastNode()
        {
            // Act
            Node lastNode = this._iterator.First();

            // Assert
            Assert.That(lastNode.Value, Is.EqualTo("AB"));
        }
    }
}
