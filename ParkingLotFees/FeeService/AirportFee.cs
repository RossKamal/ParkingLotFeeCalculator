namespace ParkingLotFeeCalculator.FreeService;

internal class AirportFee : ILocationFee
{
    private const int MotorcycleParked1Hour = 1;
    private const int MotorcycleParked8Hours = 8;
    private const int MotorcycleParked24Hours = 24;
    private const int CarParkedLessThan12Hours = 12;
    private const int CarParkedLessThan24Hours = 24;

    private const int MotorcycleFeeLessThan8Hours = 40;
    private const int MotorcycleFeeLessThan24Hours = 60;
    private const int CarFeeLessThan12Hours = 60;
    private const int CarFeeLessThan24Hours = 80;

    public double CalculateParkFee(VehicleType vehicleType, double parkingDurationInMinutes)
    {
        var parkedHours = Math.Floor(parkingDurationInMinutes / 60);

        double parkedFee = 0;

        switch (vehicleType)
        {
            case VehicleType.MotorcycleOrScooter:
                parkedFee = MotorcycleFee(parkedHours);
                break;

            case VehicleType.CarOrSUV:
                parkedFee = CarFee(parkedHours);
                break;
            case VehicleType.BusOrTruck:
                break;
            default:
                break;
        }

        return Math.Round(parkedFee, 2);
    }

    private static double MotorcycleFee(double parkedHours)
    {
        double parkedFee;
        if (parkedHours <= MotorcycleParked1Hour)
        {
            parkedFee = 0;
        }
        else if (parkedHours < MotorcycleParked8Hours)
        {
            parkedFee = MotorcycleFeeLessThan8Hours;
        }
        else if (parkedHours < MotorcycleParked24Hours)
        {
            parkedFee = MotorcycleFeeLessThan24Hours;
        }
        else
        {
            parkedFee = Math.Ceiling(parkedHours / 24) * 80;
        }

        return parkedFee;
    }

    private static double CarFee(double parkedHours)
    {
        double parkedFee;
        if (parkedHours < CarParkedLessThan12Hours)
        {
            parkedFee = CarFeeLessThan12Hours;
        }
        else if (parkedHours < CarParkedLessThan24Hours)
        {
            parkedFee = CarFeeLessThan24Hours;
        }
        else
        {
            parkedFee = Math.Ceiling(parkedHours / 24) * 100;
        }

        return parkedFee;
    }
}