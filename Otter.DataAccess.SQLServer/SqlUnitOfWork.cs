using Microsoft.EntityFrameworkCore;
using Otter.DataAccess.Exceptions;
using Otter.DataAccess.Repositories;
using Otter.DataAccess.SQLServer.Repositories;

namespace Otter.DataAccess.SQLServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private ICurrencyRepository _currencyRepository;
        private ApplicationDbContext context;
        private IPolicyRepository _policyRepository;
        private IProvinceRepository _provinceRepository;
        private ICityRepository _cityRepository;
        private IDiscountRepository _discountRepository;
        private IConfigurationRepository _configurationRepository;

        public SqlUnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public void Dispose()
        {
        }

        public ICurrencyRepository CurrencyRepository => _currencyRepository ??= new CurrencyRepository(context);
        public IPolicyRepository PolicyRepository => _policyRepository ??= new PolicyRepository(context);
        public IProvinceRepository ProvinceRepository => _provinceRepository ??= new ProvinceRepository(context);
        public ICityRepository CityRepository => _cityRepository ??= new CityRepository(context);
        public IDiscountRepository DiscountRepository => _discountRepository ??= new DiscountRepository(context);
        public IConfigurationRepository ConfigurationRepository => _configurationRepository ??= new ConfigurationRepository(context);

        /// <exception cref="DatabaseException">Condition.</exception>
        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }
    }
}