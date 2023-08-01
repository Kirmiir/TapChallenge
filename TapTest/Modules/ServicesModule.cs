using Microsoft.Extensions.DependencyInjection;
using TapTest.Interfaces;
using TapTest.Services;

namespace TapTest.Modules
{
    internal static class ServicesModule
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection collection)
        {
            return collection
                .AddSingleton<IDepartmentService, DepartmentService>()
                .AddTransient<IInstituteService, InstituteService>();
            ;
        }
    }
}
