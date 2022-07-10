using Otter.Common.Entities;
using Otter.DataAccess.Repositories;

namespace Otter.DataAccess.SQLServer.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}