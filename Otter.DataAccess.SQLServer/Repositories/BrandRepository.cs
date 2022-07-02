using Otter.Common.Entities;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}