using TapTest.Interfaces;

namespace TapTest.Models
{
    public class Application : IApplication
    {
        public char Subject { get; init; }

        public Dictionary<string, int> Scores { get; init; }
    }
}
