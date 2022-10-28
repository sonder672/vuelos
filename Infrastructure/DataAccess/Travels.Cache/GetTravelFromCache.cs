using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Travels.Contracts;
using Travels.DTOs;

public class GetTravelFromCache : IGetResultTravelList
{
    private readonly IDistributedCache _cache;
    private readonly ISearchTravelList _travelList;
    private const string CACHE_KEY = "TRAVEL";

    public GetTravelFromCache(IDistributedCache cache, ISearchTravelList travelList)
    {
        _cache = cache;
        _travelList = travelList;
    }

    public async Task<List<GetTravelListDTO>?> GetTravel(string key)
    {
        byte[] value = await _cache.GetAsync(key);
        if (value == null)
        {
            List<GetTravelListDTO>? travels = await _travelList.GetTravels();

            if (travels != null)
                await addToCache(travels);

            return travels;
        }

        return JsonSerializer.Deserialize<List<GetTravelListDTO>?>(value);
    }

    private async Task addToCache(List<GetTravelListDTO> travels)
    {
        await _cache.SetAsync(CACHE_KEY, toByteArray(travels));
    }

    private byte[] toByteArray(List<GetTravelListDTO> obj)
    {
        return JsonSerializer.SerializeToUtf8Bytes(obj);
    }
}