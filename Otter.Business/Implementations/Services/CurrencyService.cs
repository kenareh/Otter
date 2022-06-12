using System.Collections.Generic;
using System.Linq;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Exceptions;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class CurrencyService : ICurrencyService
    {
        private IUnitOfWork _unitOfWork;
        private ICurrencyFactory _currencyFactory;

        public CurrencyService(IUnitOfWork unitOfWork, ICurrencyFactory currencyFactory)
        {
            _unitOfWork = unitOfWork;
            _currencyFactory = currencyFactory;
        }

        public List<CurrencyDto> GetAll()
        {
            var currencies = _unitOfWork.CurrencyRepository.Find().ToList();
            return _currencyFactory.CreateDto(currencies).ToList();
        }

        public CurrencyDto GetById(int id)
        {
            var currency = _unitOfWork.CurrencyRepository.Find(p => p.Id == id).FirstOrDefault();
            if (currency == null)
            {
                throw new EntityNotFoundException("currency", id.ToString(), typeof(CurrencyDto));
            }

            return _currencyFactory.CreateDto(currency);
        }
    }
}