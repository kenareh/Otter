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
        private IPolicyFileRepository _policyFileRepository;
        private ISpeakerTestNumberRepository _speakerTestNumberRepository;
        private IBrandRepository _brandRepository;
        private IPaymentRepository _paymentRepository;
        private IAgentRepository _agentRepository;

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
        public IPolicyFileRepository PolicyFileRepository => _policyFileRepository ??= new PolicyFileRepository(context);
        public ISpeakerTestNumberRepository SpeakerTestNumberRepository => _speakerTestNumberRepository ??= new SpeakerTestNumberRepository(context);
        public IBrandRepository BrandRepository => _brandRepository ??= new BrandRepository(context);
        public IPaymentRepository PaymentRepository => _paymentRepository ??= new PaymentRepository(context);
        public IAgentRepository AgentRepository => _agentRepository ??= new AgentRepository(context);

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