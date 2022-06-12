using Otter.Common.Entities;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public class PolicyRepository : BaseRepository<Policy>, IPolicyRepository
    {
        public PolicyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}