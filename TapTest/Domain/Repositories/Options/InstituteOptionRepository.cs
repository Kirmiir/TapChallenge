using TapTest.Configuration;
using TapTest.Options;

namespace TapTest.Domain.Repositories.Options
{
    internal class InstituteOptionRepository : IInstituteOptionRepository
    {
        private readonly ConfigurationManager _manager;

        public InstituteOptionRepository(ConfigurationManager manager)
        {
            _manager = manager;
        }

        public InstituteOptions Load(string filename)
        {
            return _manager.GetInstituteOptions(filename);
        }
    }
}
