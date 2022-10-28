using Travels.DTOs;

namespace Travels.Services;

public interface InterfaceTest
{
    public Task<List<GetTravelListDTO>?> Handle(DesiredDestinationDTO destination);
}