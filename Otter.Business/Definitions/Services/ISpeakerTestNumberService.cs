using System;

namespace Otter.Business.Definitions.Services
{
    public interface ISpeakerTestNumberService
    {
        long SelectRandomNumberVoiceId();

        bool IsValid(int number, int voiceNumberId);
    }
}