using System.Text.Json;
using Travels.Contracts;
using Travels.DTOs;

namespace Travels.ExternalAPI;

public class GetTravelList : ISearchTravelList
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GetTravelList(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<List<GetTravelListDTO>?> GetTravels()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException();
        } 

        var content = await response.Content.ReadAsStringAsync();
        List<GetTravelListDTO>? flightList = JsonSerializer.Deserialize<List<GetTravelListDTO>>(content);
        return flightList;
    }
}