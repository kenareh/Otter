using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;

namespace Otter.Business.Definitions.Services
{
    public interface IPaymentService
    {
        PaymentDto Get(long id);

        List<PaymentDto> Get();

        List<PaymentDto> GetByPolicyId(long policyId);

        Task<PaymentRequestResultDto> InsertPaymentRequestAsync(Guid policyGuid);

        Task<string> VerifyAsync(string token, string responseCode, string acceptorId, string amount, string paymentId, string requestId, string retrievalReferenceNumber, string systemTraceAuditNumber, string maskedPan);

        PaymentDto Get(Guid guid);
    }
}