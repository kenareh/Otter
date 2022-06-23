using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Otter.ExternalService.Utilities;

namespace Otter.ExternalService.Sms
{
    public interface ISmsService
    {
        Task SendAsync(string message, List<string> numbers);
    }

    public class SmsService : ISmsService
    {
        private IInternalClientService _internalClientService;
        private readonly string _externalServiceAddress;

        public SmsService(IConfiguration configuration, IInternalClientService internalClientService)
        {
            _externalServiceAddress = configuration.GetValue<string>("ExternalServiceMiddleware:Address");

            _internalClientService = internalClientService;
        }

        public async Task SendAsync(string message, List<string> numbers)
        {
            var dto = new SmsProviderDto()
            {
                Text = message,
                PhoneNumbers = numbers
            };

            try
            {
                await _internalClientService.PostAsync(_externalServiceAddress + "sms", dto);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}