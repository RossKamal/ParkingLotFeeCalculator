namespace ParkingLotFeeCalculator.ParkModel;

public class Spot
{
    public int SpotNumber { get; private set; }
    public VehicleType VehicleType { get; private set; }
    public LocationType LocationType { get; private set; }
    public bool IsOccupied { get; set; }

    public Spot(int spotNumber, VehicleType vehicleType, LocationType locationType)
    {
        SpotNumber = spotNumber;
        VehicleType = vehicleType;
        LocationType = locationType;
        IsOccupied = false;
    }
}