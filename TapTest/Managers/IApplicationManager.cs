using TapTest.Interfaces;
using TapTest.Models;
using TapTest.Options;

namespace TapTest.Managers;

public interface IApplicationManager
{
    List<Application> GetPassedApplications(char departmentKey, ICollection<SelectionOptions> filters);
    bool Add(IApplication application);
}