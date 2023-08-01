using TapTest.Interfaces;
using TapTest.Models;
using TapTest.Options.SelectionRule;

namespace TapTest.Domain.Filters
{
    public class TopNFilter : IFilter
    {
        public TopNFilter(TopNFilterOption settings)
        {
            _settings = settings;
        }

        private readonly TopNFilterOption _settings;
        public IEnumerable<Application> Filter(IEnumerable<Application> application)
        {
            return application
                .OrderByDescending(a => a.Scores[_settings.OrderBy])
                .Take(_settings.N);
        }
    }
}
