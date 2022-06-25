using Otter.Common.Entities;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public class SpeakerTestNumberRepository : BaseRepository<SpeakerTestNumber>, ISpeakerTestNumberRepository
    {
        public SpeakerTestNumberRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}