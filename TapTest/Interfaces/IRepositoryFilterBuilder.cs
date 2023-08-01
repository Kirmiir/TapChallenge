using TapTest.Options;

namespace TapTest.Interfaces;

internal interface IRepositoryFilterBuilder
{
    IFilter Build(SelectionOptions option);
}