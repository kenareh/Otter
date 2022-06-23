using System;
using System.Threading.Tasks;
using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface IPolicyService
    {
        Task<Guid> InsertBasicInformation(BasicInformationRequestDto dto);

        PolicyDto Get(Guid guid);

        PolicyDto MobileConfirmByOtp(Guid guid, string otp);

        PolicyDto AddImeiFile(Guid guid, string imeiFileBase64);

        PolicyFileDto GetImeiFile(Guid guid);

        PolicyDto AddBoxImageFile(Guid guid, string imeiFileBase64);

        PolicyFileDto GetBoxImageFile(Guid guid);
    }
}