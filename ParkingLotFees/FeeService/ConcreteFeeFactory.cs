namespace ParkingLotFeeCalculator.FreeService;

public class ConcreteFeeFactory : FeeFactory
{
    public override ILocationFee GetFee(LocationType locationType)
    {
        return locationType switch
        {
            LocationType.Mall => new MallFee(),
            LocationType.Stadium => new StadiumFee(),
            LocationType.Airport => new AirportFee(),
            _ => throw new NotImplementedException()
        };
    }
}