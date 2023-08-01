namespace TapTest.Options.SelectionRule
{
    [Serializable]
    public class TopNFilterOption
    {
        public string OrderBy { get; set; }
        public int N { get; set; }
    }
}
