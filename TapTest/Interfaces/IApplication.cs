namespace TapTest.Interfaces
{
    public interface IApplication
    {
        public char Subject { get; }

        public Dictionary<string, int> Scores { get; }
    }
}
