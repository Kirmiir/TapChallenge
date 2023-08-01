using Microsoft.Extensions.Logging;
using TapTest.Models;

namespace TapTest.Domain.Repositories
{
    public class InstituteRepository : BaseRepository<Institute>
    {
        private int Id { get; set; }

        public InstituteRepository(ILogger logger) : base(logger)
        {
            Id = 1;
        }

        public override Institute Get(int id)
        {
            var institute = _entities.FirstOrDefault(i => i.Id == id);
            if (institute != null) return institute;

            _logger.LogError($"Institute with id: {id} is not found.");
            throw new Exception("Institute not found.");
        }

        public override void Add(Institute entity)
        {
            entity.Id = Id++;
            base.Add(entity);
        }
    }
}
