using Microsoft.Extensions.Logging;
using TapTest.Models;

namespace TapTest.Domain.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        private int _id;

        public DepartmentRepository(ILogger logger) : base(logger)
        {
            _id = 1;
        }

        public override Department Get(int id)
        {
            var department = _entities.FirstOrDefault(e => e.Id == id);
            if (department != null) return department;

            _logger.LogError($"Department with id: {id} is not found.");
            throw new Exception("Department not found.");
        }

        public override List<Department> GetAll()
        {
            return _entities;
        }

        public Department GetBySubject(char key)
        {
            var department = _entities.FirstOrDefault(d => d.Key == key);
            if (department != null) return department;

            _logger.LogError($"Department with key: {key} is not found.");
            throw new Exception("Department not found.");
        }

        public int GetDepartmentIdByKey(char key)
        {
            return GetBySubject(key).Id;
        }

        public override void Add(Department entity)
        {
            entity.Id = _id++;
            base.Add(entity);
        }
    }
}
