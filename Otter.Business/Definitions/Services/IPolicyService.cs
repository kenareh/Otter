using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface IPolicyService
    {
        PolicyDto InsertBasicInformation(BasicInformationRequestDto dto);
    }
}