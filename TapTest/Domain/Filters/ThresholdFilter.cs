using TapTest.Interfaces;
using TapTest.Models;
using TapTest.Options.SelectionRule;

namespace TapTest.Domain.Filters
{
    public class ThresholdFilter : IFilter
    {
        public ThresholdFilter(ThresholdFilterOption settings)
        {
            _settings = settings;
        }

        private readonly ThresholdFilterOption _settings;

        public bool Filter(Application application)
        {
            return _settings.Bindings.Select(bnd => application.Scores.TryGetValue(bnd, out var score) ? score : throw new Exception($"Subject {bnd} is not found")).Sum() >= _settings.Threshold;
        }

        public IEnumerable<Application> Filter(IEnumerable<Application> application)
        {
            return application.Where(Filter);
        }
    }
}
