using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Otter.ExternalService.Dto;

namespace Otter.ExternalService
{
    public class LinkShortenerService : ILinkShortenerService
    {
        #region Fields

        private readonly string _linkShortenerAddress;
        private readonly string _username;
        private readonly string _password;

        #endregion Fields

        #region Constructor

        public LinkShortenerService(IConfiguration configuration)
        {
            _linkShortenerAddress = configuration.GetSection("ShortLink:Address").Value;
            _username = configuration.GetSection("ShortLink:Username").Value;
            _password = configuration.GetSection("ShortLink:Password").Value;
        }

        #endregion Constructor

        #region Methods

        public async Task<string> ShortLinkAsync(string link)
        {
            HttpClient client = new HttpClient();

            var json = JsonConvert.SerializeObject(new AbsoluteUrlDto() { AbsoluteUrl = link });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // var response = await client.PostAsync("https://localhost:44322/api/v2/short-link?username=asdsa&password=asdad", content);
            var url = _linkShortenerAddress + $"v2/short-link?username={_username}&password={_password}";
            var response = await client.PostAsync(url, content);
            var resp = await response.Content.ReadAsStringAsync();

            return resp;
        }

        #endregion Methods
    }
}