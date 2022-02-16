using Microsoft.AspNetCore.Html;

namespace Command_Web.ViewModels
{
    /// <summary>
    /// View Model used to configure HTML style of text to display on the webpage.
    /// </summary>
    public class StyleViewModel
    {
        /// <summary>
        /// Gets or sets the HTML style for text.
        /// </summary>
        public HtmlString HtmlStyle { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleViewModel"/> class.
        /// </summary>
        /// <param name="rawHtml">The raw HTML string.</param>
        public StyleViewModel(string rawHtml)
        {
            this.HtmlStyle = new HtmlString(rawHtml);
        }
    }
}
