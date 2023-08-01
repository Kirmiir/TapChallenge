using TapTest.Models;

namespace TapTest.Interfaces
{
    internal interface IFilter
    {
        public IEnumerable<Application> Filter(IEnumerable<Application> application);
    }
}
