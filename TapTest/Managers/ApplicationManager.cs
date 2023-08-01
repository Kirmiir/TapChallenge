using TapTest.Domain.Filters;
using TapTest.Interfaces;
using TapTest.Models;
using TapTest.Options;

namespace TapTest.Managers
{
    /// <summary>
    /// Manager to work with application.
    /// </summary>
    public class ApplicationManager : IApplicationManager
    {
        private readonly IApplicationRepository _repository; 
        private readonly IRepositoryFilterBuilder _filterBuilder;

        public ApplicationManager(IApplicationRepository repository)
        {
            _filterBuilder = new FilterBuilder();
            _repository = repository;
        }

        /// <summary>
        /// Apply filters for application. Filters are applied in manager in order to avoid implementation in different repositories.
        /// </summary>
        /// <param name="departmentKey"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public List<Application> GetPassedApplications(char departmentKey, ICollection<SelectionOptions> filters)
        {
            return filters
            .Select(c => _filterBuilder.Build(c))
                .Aggregate(_repository.GetApplication(departmentKey).AsEnumerable(), (enumerable, filter) => filter.Filter(enumerable))
                .ToList();
        }

        public bool Add(IApplication application)
        {
            return _repository.Add(new Application()
            {
                Scores = application.Scores,
                Subject = application.Subject
            });
        }
    }
}
