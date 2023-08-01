using TapTest.Configuration;
using TapTest.Options;

namespace TapTest.Domain.Repositories.Options
{
    internal class SubjectOptionRepository : ISubjectOptionRepository
    {
        private readonly ConfigurationManager _manager;

        public SubjectOptionRepository(ConfigurationManager manager)
        {
            _manager = manager;
        }

        public SubjectOption[] GetSubjectOptions(string filename)
        {
            return _manager.GetParserSubjectOptions(filename);
        }
    }
}
