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
        TraverseResult Find(string value, bool isLeftHanded);
    }
}
