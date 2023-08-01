using TapTest.Options;

namespace TapTest.Domain.Repositories.Options;

internal interface IInstituteOptionRepository
{
    InstituteOptions Load(string filename);
}