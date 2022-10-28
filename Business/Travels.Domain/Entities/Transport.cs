namespace Travels.Domain.Entities;

public class Transport
{
    private string _flightNumber;
    private string _flightCarrier;

    public Transport(string flightNumber, string flightCarrier)
    {
        _flightNumber = flightNumber;
        _flightCarrier = flightCarrier;
    }

    public string FlightNumber { get { return _flightNumber; } }
    public string FlightCarrier { get { return _flightCarrier; } }


}