using Travels.DTOs;

namespace Travels.Contracts;

public interface IGetResultTravelList
{
    public Task<List<GetTravelListDTO>?> GetTravel(string key);
}