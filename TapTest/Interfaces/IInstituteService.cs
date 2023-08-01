using TapTest.Options;

namespace TapTest.Interfaces;

/// <summary>
/// Contract to work with Institute object
/// </summary>
internal interface IInstituteService
{
    bool Apply(int instituteId, IApplication application);

    IInstitute Create(InstituteOptions options);

    IReadOnlyCollection<IApplication> GetSuccessApplicants(int instituteId);
}