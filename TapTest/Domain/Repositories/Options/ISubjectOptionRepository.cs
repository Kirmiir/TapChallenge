using TapTest.Options;

namespace TapTest.Domain.Repositories.Options;

internal interface ISubjectOptionRepository
{
    SubjectOption[] GetSubjectOptions(string filename);
}