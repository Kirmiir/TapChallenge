using TapTest.Domain.Repositories;
using TapTest.Interfaces;
using TapTest.Managers;
using TapTest.Models;
using TapTest.Options;

namespace TapTest.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IApplicationManager _applicationManager;
        private readonly BaseRepository<Department> _departmentRepository;

        public DepartmentService(IApplicationManager applicationManager, BaseRepository<Department> departmentRepository)
        {
            _applicationManager = applicationManager;
            _departmentRepository = departmentRepository;
        }

        public IDepartment Create(DepartmentOptions options)
        {
            var department = new Department() { SelectionStages = options.SelectionOptions, Key = options.DepartmentKey };

            _departmentRepository.Add(department);
            return department;
        }

        public bool Apply(int departmentId, IApplication application)
        {
            return _applicationManager.Add(application);
        }

        public IReadOnlyCollection<IApplication> GetSuccessApplicants(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            return _applicationManager.GetPassedApplications(department.Key, department.SelectionStages);
        }
    }
}
