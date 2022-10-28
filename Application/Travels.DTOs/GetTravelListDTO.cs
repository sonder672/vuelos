namespace Travels.DTOs;

public class GetTravelListDTO
{
    public string departureStation { get; }
    public string arrivalStation { get; }
    public string flightCarrier { get; }
    public string flightNumber { get; }
    public double price { get; }

    public GetTravelListDTO(string departureStation, string arrivalStation, string flightCarrier, string flightNumber, double price)
    {
        this.departureStation = departureStation;
        this.arrivalStation = arrivalStation;
        this.flightCarrier = flightCarrier;
        this.flightNumber = flightNumber;
        this.price = price;
    }
}