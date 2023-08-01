using Microsoft.Extensions.Logging;
using TapTest.Domain.Repositories;
using TapTest.Interfaces;
using TapTest.Models;
using TapTest.Options;

namespace TapTest.Services
{

    /// <summary>
    /// Service to work with Institute.
    /// </summary>
    public class InstituteService : IInstituteService
    {
        private readonly IDepartmentService _departmentService;
        private readonly BaseRepository<Institute> _repository;
        private readonly ILogger _logger;

        public InstituteService(IDepartmentService departmentService, BaseRepository<Institute> repository, ILogger logger)
        {
            _departmentService = departmentService;
            _repository = repository;
            _logger = logger;
        }

        public bool Apply(int instituteId, IApplication application)
        {
            var departmentId = _repository.Get(instituteId)?.GetDepartmentByKey(application.Subject)?.Id;
            if (!departmentId.HasValue)
            {
                _logger.LogError("Department is not found.");
                throw new Exception($"Not found");
            }
            return _departmentService.Apply(departmentId.Value, application);
        }

        public IInstitute Create(InstituteOptions options)
        {
            var institute = new Institute();

            foreach (var department in options.Departments)
            {
                institute.AddDepartment(_departmentService.Create(department));
            }
            _repository.Add(institute);

            return institute;
        }

        public IReadOnlyCollection<IApplication> GetSuccessApplicants(int instituteId)
        {
            var institute = _repository.Get(instituteId);
            return institute.GetDepartments().SelectMany(c => _departmentService.GetSuccessApplicants(c.Id)).ToList();
        }
    }
}
