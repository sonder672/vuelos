namespace Travels.DTOs;

public class DesiredDestinationDTO
{
    public string Origin { get; }
    public string Destination { get; }

    public DesiredDestinationDTO(string origin, string destination)
    {
        Origin = origin;
        Destination = destination;
    }
}