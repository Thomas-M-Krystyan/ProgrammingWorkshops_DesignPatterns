using System;

namespace Strategy.Exercise.Result
{
    /// <summary>
    /// The result of graph traverse algorithm.
    /// </summary>
    public readonly struct TraverseResult
    {
        /// <summary>
        /// Gets a value indicating whether the looked up value was found.
        /// </summary>
        public bool IsFound { get; }
        
        private readonly string _path;

        /// <summary>
        /// Gets all the visited nodes (from starting point to the looked up value).
        /// <para>
        ///   Example: "ABCD"
        /// </para>
        /// </summary>
        public string Path
        {
            get { return this._path ?? String.Empty; }
        }

        /// <summary>
        /// Gets the count of all visited nodes (from starting point to the looked up value).
        /// <para>
        ///   Example: 4
        /// </para>
        /// </summary>
        public ushort Count { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraverseResult"/> class.
        /// </summary>
        /// <param name="isFound">The result of look up.</param>
        /// <param name="path">The walked through path.</param>
        /// <param name="count">The number of visited nodes.</param>
        public TraverseResult(bool isFound, string path, ushort count)
        {
            this.IsFound = isFound;
            this._path = path;
            this.Count = count;
        }
    }
}
