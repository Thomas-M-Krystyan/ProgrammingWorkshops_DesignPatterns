namespace Facade.ViewModels
{
    /// <summary>
    /// The result to be displayed on the HTML view.
    /// </summary>
    public sealed class ResultViewModel
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Determines whether custom input fields should be rendered.
        /// </summary>
        public bool ShowInput { get; set; }
    }
}
