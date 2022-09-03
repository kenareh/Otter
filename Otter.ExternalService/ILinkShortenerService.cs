using System.Threading.Tasks;

namespace Otter.ExternalService
{
    public interface ILinkShortenerService
    {
        Task<string> ShortLinkAsync(string link);
    }
}