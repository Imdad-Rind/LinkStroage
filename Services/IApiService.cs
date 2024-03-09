using LinkStorage.Models;

namespace LinkStorage.Services;

public interface IApiService
{
    Task<EmbedCodeApiResponce> EmbededContent(String url);
}