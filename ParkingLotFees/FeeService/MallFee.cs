namespace ParkingLotFeeCalculator.FreeService;

internal class MallFee : ILocationFee
{
    private const int RateForMotorcyclePerHour = 10;
    private const int RateForCarPerHour = 20;
    private const int RateForBusPerHour = 50;

    private readonly Dictionary<VehicleType, int> _feePerHour = new()
    {
        { VehicleType.MotorcycleOrScooter, RateForMotorcyclePerHour },
        { VehicleType.CarOrSUV, RateForCarPerHour },
        { VehicleType.BusOrTruck, RateForBusPerHour }
    };

    public double CalculateParkFee(VehicleType vehicleType, double parkingDurationInMinutes)
    {
        var totalTimeInHours = Math.Ceiling(parkingDurationInMinutes / 60.0);
        var parkedFee = totalTimeInHours * GetHourVehiclePrice(vehicleType);
        return Math.Round(parkedFee, 2);
    }

    private int GetHourVehiclePrice(VehicleType vehicleType)
    {
        if (_feePerHour.TryGetValue(vehicleType, out var value))
        {
            return value;
        }

        return 0;
    }
}