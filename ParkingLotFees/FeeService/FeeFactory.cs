namespace ParkingLotFeeCalculator.FreeService;

public abstract class FeeFactory
{
    public abstract ILocationFee GetFee(LocationType locationType);
}