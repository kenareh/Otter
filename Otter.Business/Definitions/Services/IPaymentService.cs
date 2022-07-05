using System.Threading.Tasks;

namespace Otter.Business.Definitions.Services
{
    public interface IPaymentService
    {
        Task GetTokenAsync(long amount, string requestId, string paymentId, string revertUrl);

        Task Verify();
    }
}