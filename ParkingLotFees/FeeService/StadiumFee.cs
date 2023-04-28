namespace ParkingLotFeeCalculator.FreeService;

internal class StadiumFee : ILocationFee
{
    private const int MotorcycleParkedLessThan4Hours = 4;
    private const int MotorcycleParkedLessThan12Hours = 12;
    private const int CarParkedLessThan4Hours = 4;
    private const int CarParkedLessThan12Hours = 12;

    private const int MotorcycleFeeLessThan4Hours = 30;
    private const int MotorcycleFeeLessThan12Hours = 60;
    private const int CarFeeLessThan4Hours = 60;
    private const int CarFeeLessThan12Hours = 120;

    public double CalculateParkFee(VehicleType vehicleType, double parkingDurationInMinutes)
    {
        var parkedHours = Math.Floor(parkingDurationInMinutes / 60);

        double parkedFee;
        if (vehicleType is VehicleType.MotorcycleOrScooter)
        {
            parkedFee = MotorcycleFee(parkedHours);
        }
        else if (vehicleType is VehicleType.CarOrSUV)
        {
            parkedFee = CarFee(parkedHours);
        }
        else
        {
            throw new NotImplementedException();
        }

        return Math.Round(parkedFee, 2);
    }

    private static double MotorcycleFee(double parkedHours)
    {
        double motorcycleFee;
        if (parkedHours < MotorcycleParkedLessThan4Hours)
        {
            motorcycleFee = MotorcycleFeeLessThan4Hours;
        }
        else if (parkedHours < MotorcycleParkedLessThan12Hours)
        {
            motorcycleFee = MotorcycleFeeLessThan12Hours;
        }
        else
        {
            motorcycleFee = MotorcycleFeeLessThan4Hours + MotorcycleFeeLessThan12Hours + 100 + (parkedHours - 12) * 100;
        }

        return motorcycleFee;
    }

    private static double CarFee(double parkedHours)
    {
        double carFee;
        if (parkedHours < CarParkedLessThan4Hours)
        {
            carFee = CarFeeLessThan4Hours;
        }
        else if (parkedHours < CarParkedLessThan12Hours)
        {
            carFee = CarFeeLessThan4Hours + CarFeeLessThan12Hours;
        }
        else
        {
            carFee = CarFeeLessThan4Hours + CarFeeLessThan12Hours + 200 + (parkedHours - 12) * 200;
        }

        return carFee;
    }
}