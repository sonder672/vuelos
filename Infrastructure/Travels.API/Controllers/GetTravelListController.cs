using Microsoft.AspNetCore.Mvc;
using Travels.DTOs;
using Travels.Services;

namespace Travels.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GetTravelListController
{
    private readonly InterfaceTest _interface;

    public GetTravelListController(InterfaceTest @interface)
    {
        _interface = @interface;
    }

    [HttpPost(Name = "GetDesiredDestination")]
    public Task<List<GetTravelListDTO>?> getTravelList(DesiredDestinationDTO destination)
    {
        var test = _interface.Handle(destination);
        return test;
    }
}