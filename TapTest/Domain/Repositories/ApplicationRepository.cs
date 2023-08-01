using Microsoft.Extensions.Logging;
using TapTest.Interfaces;
using TapTest.Models;

namespace TapTest.Domain.Repositories
{
    public sealed class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ILogger logger) : base(logger)
        {
        }

        public override Application Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(Application application)
        {
            base.Add(application);
            return true;
        }

        public List<Application> GetApplication(char departmentKey)
        {
            return _entities.Where(a => a.Subject == departmentKey).ToList();
        }
    }
}
