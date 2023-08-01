using TapTest.Interfaces;
using TapTest.Models;

namespace TapTest.Loader
{
    public class TextReaderLoader : IDataLoader
    {
        private ApplicationParser _parser;
        private TextReader _reader;

        public TextReaderLoader(ApplicationParser parser, TextReader reader)
        {
            _parser = parser;
            _reader = reader;
        }

        public List<Application> Load()
        {
            var N = int.Parse(_reader.ReadLine());
            var result = new List<Application>(N);

            for (int i = 0; i < N; i++)
            {
                result.Add(_parser.Parse(_reader.ReadLine()));
            }
            return result;
        }
    }
}
