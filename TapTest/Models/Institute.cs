using TapTest.Interfaces;

namespace TapTest.Models
{
    public class Institute : IInstitute
    {
        private Dictionary<char, IDepartment> Departments { get; set; }
        public int Id { get; set; }

        public Institute()
        {
            Departments = new Dictionary<char, IDepartment>();
        }

        public IDepartment GetDepartmentByKey(char key)
        {
            if (Departments.TryGetValue(key, out var department))
            {
                return department;
            }

            return null;
        }
        public IReadOnlyCollection<IDepartment> GetDepartments()
        {
            return Departments.Values;
        }

        public void AddDepartment(IDepartment department)
        {
            Departments[department.Key] = department;
        }
    }
}
