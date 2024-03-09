using LinkStorage.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinkStorage.Services.ServicesImpl;

public class ApiServiceImpl : IApiService
{
    private readonly HttpClient _client;

    public ApiServiceImpl(HttpClient client)
    {
        _client = client;
    }

    public async Task<EmbedCodeApiResponce> EmbededContent(String url)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new Exception("Please provide a valid URL.");
        }

        try
        {
            var apiKey = "";
            var requestUrl = $"https://iframe.ly/api/iframely?url={Uri.EscapeDataString(url)}&api_key={Uri.EscapeDataString(apiKey)}";

            var response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<EmbedCodeApiResponce>(content);
            
            return data;
        
        }
        catch (HttpRequestException ex)
        {
            throw new (ex.Message );
        }

        
        
    }
}