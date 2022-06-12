using Otter.Common.Entities;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}