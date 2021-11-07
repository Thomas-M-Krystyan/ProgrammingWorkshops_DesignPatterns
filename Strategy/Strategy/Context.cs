using Strategy.Exercise.TraverseStrategies.Interfaces;

namespace Strategy.Strategy
{
    /// <summary>
    /// The context of strategy.
    /// </summary>
    public sealed class Context
    {
        private IStrategy _strategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        /// <summary>
        /// Sets the strategy.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        /// <inheritdoc cref="IStrategy.Find"/>
        public string Find(string value, bool isLeftHanded)
        {
            var result = this._strategy.Find(value, isLeftHanded);

            var textResult = $"Was found: {result.IsFound}\n" +
                             $"Traversed path: \"{result.Path}\"\n" +
                             $"Visited nodes: {result.Count}";

            return textResult;
        }
    }
}
