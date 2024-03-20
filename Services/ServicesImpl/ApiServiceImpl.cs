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
    /*
     * It the Iframely API Service where url link is converted raw html for embed
     */
    public async Task<EmbedCodeApiResponce> EmbededContent(String url)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new Exception("Please provide a valid URL.");
        }

        try
        {
            
            var apiKey = "";  // put your Iframely API key here
            
            // AIP Request url
            var requestUrl = $"https://iframe.ly/api/iframely?url={Uri.EscapeDataString(url)}&api_key={Uri.EscapeDataString(apiKey)}";

            var response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            
            
            /* Deserialize incomming json object to string */
            var data = JsonConvert.DeserializeObject<EmbedCodeApiResponce>(content);
            
            return data;
        
        }
        catch (HttpRequestException ex)
        {
            throw new (ex.Message );
        }

        
        
    }
}