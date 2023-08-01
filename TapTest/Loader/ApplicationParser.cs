using TapTest.Models;
using TapTest.Options;

namespace TapTest.Loader
{
    /// <summary>
    /// Application Parser from string.
    /// </summary>
    public class ApplicationParser
    {
        private readonly Dictionary<string, int> _map;

        public ApplicationParser(IEnumerable<SubjectOption> subjects)
        {
            _map = subjects.ToDictionary(c => c.Binding, c => c.ColumnIndex);
        }

        public Application Parse(string str)
        {
            var arr = str.Split(" ");
            var application = new Application
            {
                Subject = arr[0][0],
                Scores = _map.ToDictionary(c => c.Key, v => int.Parse(arr[v.Value + 1]))
            };
            return application;
        }
    }
}
