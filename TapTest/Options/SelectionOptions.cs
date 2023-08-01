using TapTest.Options.SelectionRule;

namespace TapTest.Options
{
    /// <summary>
    /// Description of selection stage in applying process.
    /// </summary>
    [Serializable]
    public class SelectionOptions
    {
        public FilterType Type { get; set; }
        /// <summary>
        /// Options of Selection Stage. JSON can be presented differently based on the type of Filter.
        /// </summary>
        public string Options { get; set; }
    }
}
