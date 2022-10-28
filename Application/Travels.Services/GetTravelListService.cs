using System.Net;
using Travels.Domain.Contracts;
using Travels.DTOs;
using Travels.Contracts;

namespace Travels.Services;

public class GetTravelListService : InterfaceTest
{
    private readonly IGetResultTravelList _getTravel;
    //private readonly ISaveTravelList _saveTravel;
    public GetTravelListService(IGetResultTravelList getTravel)
    {
        _getTravel = getTravel;
    }

    public async Task<List<GetTravelListDTO>?> Handle(DesiredDestinationDTO destination)
    {
        List<GetTravelListDTO>? travelList = await _getTravel.GetTravel("TRAVEL");

        var origins = travelList?.Where(x => x.departureStation == destination.Origin);

        if (origins?.Count() == 0)
        {
            throw new WebException("Not found");
        }

        var directTrip = origins?.Where(x => x.arrivalStation == destination.Destination);

        if (directTrip?.Count() == 1)
        {
            return directTrip.ToList();
        }

        foreach (var stopover in origins)
        {
            var originsByArrival = travelList?.Where(x => x.departureStation == stopover.arrivalStation);
            var finalDestination = originsByArrival?.Where(x => x.arrivalStation == destination.Destination).ToList();

            if (finalDestination?.Count() == 1)
            {
                return finalDestination;
            }
        }
        throw new WebException("Not found");
    }
}