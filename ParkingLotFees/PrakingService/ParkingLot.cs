namespace ParkingLotFeeCalculator.ParkingService;

public class ParkingLot
{
    private readonly int _carCapacity;
    private readonly int _motorcycleCapacity;
    private readonly int _busCapacity;
    private int _availableCars;
    private int _availableMotorcycles;
    private int _availableBuses;

    public LocationType LocationType { get; internal set; }

    private IList<Spot> _spots { get; set; } = new List<Spot>();

    public ParkingLot(LocationType locationType, int motorcycleCapacity, int carCapacity, int busCapacity)
    {
        _motorcycleCapacity = motorcycleCapacity;
        _carCapacity = carCapacity;
        _busCapacity = busCapacity;

        _availableCars = carCapacity;
        _availableMotorcycles = motorcycleCapacity;
        _availableBuses = busCapacity;

        LocationType = locationType;

        CreateParkingSpots();
    }

    private void CreateParkingSpots()
    {
        if (_motorcycleCapacity > 0)
        {
            CreateSpots(VehicleType.MotorcycleOrScooter, _motorcycleCapacity);
        }

        if (_carCapacity > 0)
        {
            CreateSpots(VehicleType.CarOrSUV, _carCapacity);
        }

        if (_busCapacity > 0)
        {
            CreateSpots(VehicleType.BusOrTruck, _busCapacity);
        }
    }

    private void CreateSpots(VehicleType vehicleType, int capacity)
    {
        for (var i = 1; i <= capacity; i++)
        {
            _spots.Add(new Spot(i, vehicleType, LocationType));
        }
    }

    internal int BookSpot(VehicleType vehicleType)
    {
        var spotNumber = FindAvailableSpot(vehicleType);
        if (spotNumber is -1)
        {
            return spotNumber;
        }

        switch (vehicleType)
        {
            case VehicleType.MotorcycleOrScooter:
                if (_availableMotorcycles > 0)
                {
                    _availableMotorcycles--;
                    _spots[spotNumber - 1].IsOccupied = true;
                    return spotNumber;
                }
                break;
            case VehicleType.CarOrSUV:
                if (_availableCars > 0)
                {
                    _availableCars--;
                    _spots[spotNumber - 1].IsOccupied = true;
                    return spotNumber;
                }
                break;
            case VehicleType.BusOrTruck:
                if (_availableBuses > 0)
                {
                    _availableBuses--;
                    _spots[spotNumber - 1].IsOccupied = true;
                    return spotNumber;
                }
                break;
        }
        return spotNumber;
    }

    internal bool ReleaseSpot(int spotNumber, VehicleType vehicleType)
    {
        switch (vehicleType)
        {
            case VehicleType.MotorcycleOrScooter:
                if (_availableMotorcycles < _motorcycleCapacity)
                {
                    _availableMotorcycles++;
                    _spots[spotNumber - 1].IsOccupied = false;
                    return true;
                }
                break;
            case VehicleType.CarOrSUV:
                if (_availableCars < _carCapacity)
                {
                    _availableCars++;
                    _spots[spotNumber - 1].IsOccupied = false;
                    return true;
                }
                break;
            case VehicleType.BusOrTruck:
                if (_availableBuses < _busCapacity)
                {
                    _availableBuses++;
                    _spots[spotNumber - 1].IsOccupied = false;
                    return true;
                }
                break;
        }

        return false;
    }

    private int FindAvailableSpot(VehicleType vehicleType)
    {
        var allocatedVehicleSpots = _spots.Where(spot => spot.VehicleType == vehicleType);
        if (allocatedVehicleSpots.Any())
        {
            for (var i = 0; i < allocatedVehicleSpots.Count(); i++)
            {
                if (!_spots[i].IsOccupied)
                {
                    return _spots[i].SpotNumber;
                }
            }
        }

        return -1;
    }
}