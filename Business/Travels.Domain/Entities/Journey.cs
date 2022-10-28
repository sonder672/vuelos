namespace Travels.Domain.Entities;

public class Journey
{
    private string _origin;
    private string _destination;
    private string _price;
    private IList<Flight> _flights;

    public Journey(string origin, string destination, string price, IList<Flight> flights)
    {
        _origin = origin;
        _destination = destination;
        _price = price;
        _flights = flights;
    }

    public string Origin { get { return _origin; } }
    public string Destination { get { return _destination; } }
    public string Price { get { return _price; } }
    public IList<Flight> Flights { get { return _flights; } }
}