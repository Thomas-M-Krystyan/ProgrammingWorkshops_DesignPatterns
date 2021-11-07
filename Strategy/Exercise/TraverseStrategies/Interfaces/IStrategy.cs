using Strategy.Exercise.Result;

namespace Strategy.Exercise.TraverseStrategies.Interfaces
{
    public interface IStrategy
    {
        /// <summary>
        /// Try to find the given element.
        /// </summary>
        /// <param name="value">The value of the Node to be found.</param>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of graph traversing algorithm will be used;
        ///   otherwise, if <c>false</c>, right-handed version will be used.
        /// </param>
        /// <returns>The result of graph traversing.</returns>
        TraverseResult Find(string value, bool isLeftHanded);

        /// <summary>
        /// Gets the algorithm's name.
        /// </summary>
        /// <returns>The friendly name of algorithm.</returns>
        string GetName();
    }
}
