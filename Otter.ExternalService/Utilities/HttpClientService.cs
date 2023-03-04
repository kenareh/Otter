using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Otter.Common.Enums;
using Otter.Common.Exceptions;

namespace Otter.ExternalService.Utilities
{
    public class HttpClientService : IHttpClientService
    {
        #region Fields

        private readonly ILogger<InternalClientService> _logger;
        private readonly IConfiguration _configuration;

        #endregion Fields

        #region Constructor

        public HttpClientService(ILogger<InternalClientService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        #endregion Constructor

        #region Methods

        public async Task<TResult> GetAsync<TResult>(string path) where TResult : class
        {
            var client = new HttpClient();
            string resp;

            try
            {
                var response = await client.GetAsync(path);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult<TResult>>(resp);

            if (apiResult == null) return default!;

            if (apiResult.IsSuccess == false)
            {
                throw new IntegratedException(apiResult.Message, apiResult.StatusCode);
            }

            return apiResult.Data;
        }

        public async Task GetAsync(string path)
        {
            var client = new HttpClient();
            string resp;

            try
            {
                var response = await client.GetAsync(path);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult>(resp);

            if (apiResult != null && apiResult.IsSuccess == false)
            {
                throw new IntegratedException(apiResult.Message, apiResult.StatusCode);
            }
        }

        public async Task<TResult> PostAsync<TResult>(string path, object data) where TResult : class
        {
            var client = new HttpClient();
            string resp;

            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(path, content);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult<TResult>>(resp);

            if (apiResult == null) return default!;

            if (apiResult.IsSuccess == false)
            {
                throw new IntegratedException(apiResult.Message, apiResult.StatusCode);
            }

            return apiResult.Data;
        }

        public async Task PostAsync(string path, object data)
        {
            var client = new HttpClient();
            string resp;

            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(path, content);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult>(resp);

            if (apiResult != null && apiResult.IsSuccess == false)
            {
                throw new IntegratedException(apiResult.Message, apiResult.StatusCode);
            }
        }

        public string GetPath(ServiceUrl url)
        {
            switch (url)
            {
                case ServiceUrl.ExternalService:
                    return _configuration.GetSection("ExternalServiceMiddleware:Address").Value;

                case ServiceUrl.FannavaranMiddleware:
                    return _configuration.GetSection("FannavaranMiddleware:Address").Value;

                case ServiceUrl.FannavaranApi:
                    return _configuration.GetSection("FannavaranApi:Address").Value;

                case ServiceUrl.ShortLink:
                    return _configuration.GetSection("ShortLink:Address").Value;

                case ServiceUrl.IPG:
                    return _configuration.GetSection("IPG:Address").Value;

                default:
                    return string.Empty;
            }
        }

        #endregion Methods
    }

    public enum ServiceUrl
    {
        ExternalService,
        FannavaranMiddleware,
        FannavaranApi,
        ShortLink,
        IPG
    }
}