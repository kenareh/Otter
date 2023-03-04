using System.Threading.Tasks;

namespace Otter.ExternalService.Utilities
{
    public interface IHttpClientService
    {
        #region Methods

        Task<TResult> GetAsync<TResult>(string path) where TResult : class;

        Task GetAsync(string path);

        Task<TResult> PostAsync<TResult>(string path, object data) where TResult : class;

        Task PostAsync(string path, object data);

        string GetPath(ServiceUrl url);

        #endregion Methods
    }
}