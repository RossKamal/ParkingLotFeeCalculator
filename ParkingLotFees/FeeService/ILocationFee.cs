namespace ParkingLotFeeCalculator.FreeService;

public interface ILocationFee
{
    double CalculateParkFee(VehicleType vehicleType, double parkingDurationInMinutes);
}