using Otter.Common.Entities;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public class PolicyFileRepository : BaseRepository<PolicyFile>, IPolicyFileRepository
    {
        public PolicyFileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}