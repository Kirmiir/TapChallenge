using Newtonsoft.Json;
using TapTest.Interfaces;
using TapTest.Options;
using TapTest.Options.SelectionRule;

namespace TapTest.Domain.Filters
{
    internal class FilterBuilder : IRepositoryFilterBuilder
    {
        public IFilter Build(SelectionOptions option)
        {
            switch (option.Type)
            {
                case FilterType.Threshold:
                    var ruleOption = JsonConvert.DeserializeObject<ThresholdFilterOption>(option.Options);
                    return new ThresholdFilter(ruleOption);
                case FilterType.Top:
                    var topOption = JsonConvert.DeserializeObject<TopNFilterOption>(option.Options);
                    return new TopNFilter(topOption);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
