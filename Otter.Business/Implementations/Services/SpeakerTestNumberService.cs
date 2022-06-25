using System;
using System.Linq;
using Otter.Business.Definitions.Services;
using Otter.Common.Exceptions;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class SpeakerTestNumberService : ISpeakerTestNumberService
    {
        private IUnitOfWork _unitOfWork;

        public SpeakerTestNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long SelectRandomNumberVoiceId()
        {
            // var randomNumber = new Random().Next(1, 100);//todo
            var randomNumber = 58;
            var number = _unitOfWork.SpeakerTestNumberRepository.Find(p => p.Order == randomNumber).FirstOrDefault();
            if (number == null)
            {
                throw new EntityNotFoundException("تست اسپیکر یافت نشد");
            }

            return number.Id;
        }

        public bool IsValid(int number, int voiceNumberId)
        {
            var voiceNumber = _unitOfWork.SpeakerTestNumberRepository.Find(p => p.Id == voiceNumberId && p.Number == number).FirstOrDefault();
            if (voiceNumber == null)
                return false;

            return true;
        }
    }
}