using System;
using System.Net;
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
    public interface IInternalClientService
    {
        /// <exception cref="IntegratedException"></exception>
        /// <exception cref="BusinessViolatedException"></exception>
        Task<TResult> GetAsync<TResult>(string path) where TResult : class;

        /// <exception cref="IntegratedException"></exception>
        /// <exception cref="BusinessViolatedException"></exception>
        Task GetAsync(string path);

        /// <exception cref="IntegratedException"></exception>
        /// <exception cref="BusinessViolatedException"></exception>
        Task<TResult> PostAsync<TResult>(string path, object data) where TResult : class;

        /// <exception cref="IntegratedException"></exception>
        /// <exception cref="BusinessViolatedException"></exception>
        Task PostAsync(string path, object data);

        string GetPath(ServiceUrl url);
    }

    public class InternalClientService : IInternalClientService
    {
        private ILogger<InternalClientService> _logger;
        private readonly IConfiguration _configuration;

        public InternalClientService(ILogger<InternalClientService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        #region Methods

        public async Task<TResult> GetAsync<TResult>(string path) where TResult : class
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            string resp;

            try
            {
                response = await client.GetAsync(path);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(response.ReasonPhrase);
                throw new IntegratedException("خطا در پاسخ سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult<TResult>>(resp);

            if (apiResult.IsSuccess == false)
            {
                throw new BusinessViolatedException(apiResult.Message, apiResult.StatusCode);
            }

            return apiResult.Data;
        }

        public async Task GetAsync(string path)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            string resp;

            try
            {
                response = await client.GetAsync(path);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(response.ReasonPhrase);
                throw new IntegratedException("خطا در پاسخ سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult>(resp);

            if (apiResult.IsSuccess == false)
            {
                throw new BusinessViolatedException(apiResult.Message, apiResult.StatusCode);
            }
        }

        public async Task<TResult> PostAsync<TResult>(string path, object data) where TResult : class
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            string resp;

            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(response.ReasonPhrase);
                throw new IntegratedException("خطا در پاسخ سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult<TResult>>(resp);

            if (apiResult == null) return default!;

            if (apiResult.IsSuccess == false)
            {
                throw new BusinessViolatedException(apiResult.Message, apiResult.StatusCode);
            }

            return apiResult.Data;
        }

        public async Task PostAsync(string path, object data)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            string resp;

            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(path, content);
                resp = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new IntegratedException("خطا در ارتباط با سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError(response.ReasonPhrase);
                throw new IntegratedException("خطا در پاسخ سرویس واسط", ApiResultStatusCode.RequestTimeout);
            }

            var apiResult = JsonConvert.DeserializeObject<ApiResult>(resp);

            if (apiResult != null && apiResult.IsSuccess == false)
            {
                throw new BusinessViolatedException(apiResult.Message, apiResult.StatusCode);
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

                default:
                    return string.Empty;
            }
        }

        #endregion Methods
    }
}