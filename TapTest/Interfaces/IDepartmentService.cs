using TapTest.Models;
using TapTest.Options;

namespace TapTest.Interfaces;

/// <summary>
/// Contract to work with Department.
/// </summary>
public interface IDepartmentService
{
    IDepartment Create(DepartmentOptions options);

    bool Apply(int departmentId, IApplication application);

    public IReadOnlyCollection<IApplication> GetSuccessApplicants(int departmentId);
}