using TapTest.Domain;
using TapTest.Models;

namespace TapTest.Interfaces
{
    /// <summary>
    /// The data loader interface that provide data.
    /// </summary>
    interface IDataLoader
    {
        List<Application> Load();
    }
}
