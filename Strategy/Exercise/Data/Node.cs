namespace Strategy.Exercise.Data
{
    /// <summary>
    /// The building element of <see cref="Graph"/>.
    /// </summary>
    public sealed class Node
    {
        /// <summary>
        /// Gets the <see cref="Node"/>'s value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets or sets the next (nested) left <see cref="Node"/>.
        /// </summary>
        public Node NextLeft { get; set; }

        /// <summary>
        /// Gets or sets the next (nested) right <see cref="Node"/>.
        /// </summary>
        public Node NextRight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">The value of the <see cref="Node"/>.</param>
        /// <param name="count">The consecutive counter.</param>
        public Node(string value, ref int count)
        {
            this.Value = value;
            count++;
        }
    }
}
