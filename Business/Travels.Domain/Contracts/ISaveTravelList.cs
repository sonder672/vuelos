using Travels.Domain.Entities;

namespace Travels.Domain.Contracts;

public interface ISaveTravelList
{
    public Journey saveTravelList(Journey travelList);
}