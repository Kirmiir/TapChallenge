using Microsoft.Extensions.DependencyInjection;
using TapTest.Configuration;
using TapTest.Domain.Repositories;
using TapTest.Domain.Repositories.Options;
using TapTest.Interfaces;
using TapTest.Managers;
using TapTest.Models;

namespace TapTest.Modules
{
    /// <summary>
    /// Configuration of DI.
    /// </summary>
    internal static class RepositoryModule
    {
        public static IServiceCollection AddRepositories(this IServiceCollection collection)
        {
            return collection
                    .AddTransient<IApplicationRepository, ApplicationRepository>()
                    .AddSingleton<IInstituteOptionRepository, InstituteOptionRepository>()
                    .AddSingleton<ISubjectOptionRepository, SubjectOptionRepository>()
                    .AddSingleton<IApplicationManager, ApplicationManager>()
                    .AddSingleton<BaseRepository<Department>, DepartmentRepository>()
                    .AddSingleton<BaseRepository<Institute>, InstituteRepository>()
                    .AddSingleton<ConfigurationManager, ConfigurationManager>();
            ;
        }
    }
}
