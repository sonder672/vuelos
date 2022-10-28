namespace Travels.Domain.Entities;

public class Flight
{
    private string _origin;
    private string _destination;
    private string _price;
    private string _flightNumber;
    private Transport _transport;

    public Flight(string origin, string destination, string price, string flightNumber, Transport transport)
    {
        _origin = origin;
        _destination = destination;
        _price = price;
        _flightNumber = flightNumber;
        _transport = transport;
    }


    public string Origin { get { return _origin; } }
    public string Destination { get { return _destination; } }
    public string Price { get { return _price; } }
    public string FlightNumber { get { return _flightNumber; } }
    public Transport Transport { get { return _transport; } }

}