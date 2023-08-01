namespace TapTest.Options
{
    /// <summary>
    /// Description of Department.
    /// </summary>
    [Serializable]
    public class DepartmentOptions
    {
        /// <summary>
        /// Stages of Selection.
        /// </summary>
        public List<SelectionOptions> SelectionOptions { get; set; }

        /// <summary>
        /// Department ID.
        /// </summary>
        public char DepartmentKey { get; set; }
    }
}
