using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using PaymentRequestResultDto = Otter.ExternalService.Dto.PaymentRequestResultDto;

namespace Otter.Business.Definitions.Services
{
    public interface IPaymentService
    {
        PaymentDto Get(long id);

        List<PaymentDto> Get();

        List<PaymentDto> GetByPolicyId(long policyId);

        Task<PaymentRequestResultDto> InsertPaymentRequestAsync(Guid policyGuid, string redirectUrl);

        PaymentDto Get(Guid guid);

        Task<string> CallBackAsync(Guid guid);
    }
}