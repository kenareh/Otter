using System.Collections.Generic;
using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface ICurrencyService
    {
        List<CurrencyDto> GetAll();

        CurrencyDto GetById(int id);
    }
}