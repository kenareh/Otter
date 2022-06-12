using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Common.Entities;

namespace Otter.Business.Implementations.Factories
{
    public class CurrencyFactory : BaseFactory<Currency, CurrencyDto>, ICurrencyFactory
    {
    }
}