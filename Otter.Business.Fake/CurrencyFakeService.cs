using System.Collections.Generic;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;

namespace Otter.Business.Fake
{
    public class CurrencyFakeService : ICurrencyService
    {
        public List<CurrencyDto> GetAll()
        {
            return new List<CurrencyDto>()
            {
                new CurrencyDto() {Id = 1, LatinName = "hamid", Title = "بیسبسیبسیب",Age = 45}
            };
        }

        public CurrencyDto GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}