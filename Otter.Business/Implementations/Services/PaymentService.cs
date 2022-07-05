using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Otter.Business.Definitions.Services;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Services
{
    public class PaymentService : IPaymentService
    {
        private IConfigurationService _configurationService;

        public PaymentService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task GetTokenAsync(long amount, string requestId, string paymentId, string revertUrl)
        {
            try
            {
                var conf = _configurationService.GetPaymentConfiguration();

                RequestClass requestClass = new RequestClass();
                // requestClass.Request.CmsPreservationId = iPGData.CmsPreservationId;
                //requestClass.Request.additionalParameters = new List<KeyValuePair<string, string>>
                //{
                //    new KeyValuePair<string, string>("nationalId","1045879569")
                //};
                requestClass.Request.AcceptorId = conf.AcceptorId;
                requestClass.Request.amount = amount;
                requestClass.Request.BillInfo = null;
                // requestClass.Request.multiplexParameters = null;
                requestClass.Request.PaymentId = paymentId;
                requestClass.Request.RequestId = requestId;
                requestClass.Request.RevertUri = revertUrl;
                requestClass.Request.terminalId = conf.TerminalId;
                requestClass.Request.RequestTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                requestClass.Request.transactionType = "Purchase";

                AESCoding.CreateAESCoding(requestClass, conf.RsaPublicKey, conf.PassPhrase, requestClass.Request.multiplexParameters == null ? false : true);

                var json = JsonConvert.SerializeObject(requestClass);

                var http = new HttpClient()
                {
                    BaseAddress = new Uri("https://ikc.shaparak.ir/api/v3/tokenization/make")
                }; ;

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync("", content);
                var resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task Verify()
        {
            throw new System.NotImplementedException();
        }
    }
}