namespace Iterator.Exercise.TraverseStrategies.Interfaces
{
    public interface IStrategy
    {
        /// <summary>
        /// Try to find the given element.
        /// </summary>
        /// <param name="isLeftHanded">
        ///   If <c>true</c> left-handed version of graph traversing algorithm will be used;
        ///   otherwise, if <c>false</c>, right-handed version will be used.
        /// </param>
        /// <returns>The result of graph traversing.</returns>
        void GetNode(bool isLeftHanded);  // TODO: Return currently iterated Node

        /// <summary>
        /// Gets the algorithm's name.
        /// </summary>
        /// <returns>The friendly name of algorithm.</returns>
        string GetName();
    }
}
