using TapTest.Domain;
using TapTest.Models;

namespace TapTest.Interfaces
{
    /// <summary>
    /// Repository for Application.
    /// </summary>
    public interface IApplicationRepository
    {
        public bool Add(Application application);
        
        public List<Application> GetApplication(char departmentKey);
    }
}
