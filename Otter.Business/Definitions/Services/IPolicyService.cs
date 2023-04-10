using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface IPolicyService
    {
        PolicyFullDto GetFull(long id);

        List<PolicyDto> Get(FilterRequestDto dto);

        List<PolicyDto> GetUncompletedPaid();

        byte[] GetExcelPoliciesForIssue(FilterRequestDto dto, string fileName);

        Task<FailedStateValidationDto> ValidateAsync(long id, FailedStateValidationDto dto);

        bool Validate(List<long> ids);

        Task<Guid> InsertBasicInformation(BasicInformationRequestDto dto);

        PolicyDto Get(Guid guid);

        Task<PolicyDto> MobileConfirmByOtpAsync(Guid guid, string otp);

        Task ReissueOtpAsync(Guid guid);

        PolicyDto AddImei(Guid guid, string imei);

        PolicyDto AddImeiFile(Guid guid, string imeiFileBase64);

        PolicyFileDto GetImeiFile(Guid guid);

        PolicyDto AddBoxImageFile(Guid guid, string imeiFileBase64);

        PolicyFileDto GetBoxImageFile(Guid guid);

        Guid GetSpeakerTestFileName(Guid policyGuid);

        bool SpeakerTest(Guid policyGuid, int number);

        PolicyDto AddMicrophoneTestFile(Guid guid, string microphoneBase64Voice);

        PolicyFileDto GetMicrophoneTestFile(Guid guid);

        PolicyDto ScreenTest(Guid guid);

        PolicyDto AddCameraFiles(Guid guid, string frontCameraBase64Image, string backCameraBase64Image);

        List<PolicyFileDto> GetCameraFiles(Guid guid);

        Task<PolicyDto> InsertPersonalInformationAsync(Guid guid, PersonalInfoDto dto);
    }
}