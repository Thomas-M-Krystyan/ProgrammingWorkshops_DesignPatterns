namespace Strategy.Exercise.Data
{
    /// <summary>
    /// The "tree" type of graph data structure.
    /// </summary>
    public static class Graph
    {
        /// <summary>
        /// Gets the first node in the <see cref="Graph"/>.
        /// </summary>
        public static Node StartNode { get; private set; }

        private static int _count;

        /// <summary>
        /// Gets the total number of all <see cref="Node"/>s.
        /// </summary>
        public static int Count => _count;

        /// <summary>
        /// Initializes the <see cref="Graph"/> class.
        /// </summary>
        static Graph()
        {
            Initialize();
        }

        /// <summary>
        /// Creates the specific graph structure.
        /// <code>
        ///        A        1st layer
        ///       / \
        ///      B   C      2nd layer
        ///     / \   \
        ///    D  [E]  F    3rd layer
        ///   / \
        ///  G   H          4th layer
        ///     / \
        ///    I   J        5th layer
        /// </code>
        /// </summary>
        private static void Initialize()
        {
            // First layer
            StartNode = new Node("A", ref _count)
            {
                // Second layer
                NextLeft = new Node("B", ref _count)
                {
                    // Third layer
                    NextLeft = new Node("D", ref _count)
                    {
                        // Fourth layer
                        NextLeft = new Node("G", ref _count),
                        NextRight = new Node("H", ref _count)
                        {
                            // Fifth layer
                            NextLeft = new Node("I", ref _count),
                            NextRight = new Node("J", ref _count)
                        }
                    },
                    NextRight = new Node("E", ref _count)
                },
                NextRight = new Node("C", ref _count)
                {
                    NextRight = new Node("F", ref _count)
                }
            };
        }
    }
}
