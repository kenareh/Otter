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

        bool SpeakerTest(Guid policyGuid, int number);

        PolicyDto AddMicrophoneTestFile(Guid guid, string microphoneBase64Voice);

        PolicyFileDto GetMicrophoneTestFile(Guid guid);

        PolicyDto WhiteDotTest(Guid guid);

        PolicyDto DarkDotTest(Guid guid);

        PolicyDto SquareTouchTest(Guid guid);
    }
}