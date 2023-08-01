using TapTest.Interfaces;
using TapTest.Options;

namespace TapTest.Models
{
    public class Department : IDepartment
    {
        public List<SelectionOptions> SelectionStages { get; init; }

        public char Key { get; set; }

        public int Id { get; set; }
        
    }
}
