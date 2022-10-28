using Travels.DTOs;

namespace Travels.Contracts;

public interface ISearchTravelList
{
    public Task<List<GetTravelListDTO>?> GetTravels();
}