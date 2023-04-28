namespace ParkingLotFeeCalculator.ParkingService;

public class ParkLocation
{
    private readonly IList<LocationType> _locationTypes = new List<LocationType>();
    private readonly IList<Receipt> _parkingReceipts = new List<Receipt>();
    private readonly IList<ParkingLot> _parkingLots = new List<ParkingLot>();
    private readonly IList<Ticket> _parkingTickets = new List<Ticket>();

    private int _parkingTicketCounter;
    private int _parkingReceiptCount;

    public IList<ParkingLot> CreateParkingLots(LocationType locationType, int motorCycleCapacity = 0, int carCapacity = 0, int busCapacity = 0)
    {
        var parkingLot = new ParkingLot(locationType, motorCycleCapacity, carCapacity, busCapacity);

        _parkingLots.Add(parkingLot);
        _locationTypes.Add(locationType);

        return _parkingLots;
    }

    public Ticket? Park(LocationType locationType, VehicleType vehicleType)
    {
        var parkingLot = _parkingLots.SingleOrDefault(x => x.LocationType == locationType)
            ?? throw new NotFoundException(nameof(ParkingLot) + "Not defined");

        var spotNumber = parkingLot.BookSpot(vehicleType);

        if (spotNumber != -1)
        {
            return CreateParkingTicket(locationType, vehicleType, spotNumber);
        }
        else
        {
            throw new NotFoundException("No space available");
        }
    }

    public Receipt? UnPark(string ticketNumber)
    {
        var parkingTicket = _parkingTickets.FirstOrDefault(ticket => ticket.Number == ticketNumber);

        if (parkingTicket != null)
        {
            var parkingLot = _parkingLots.SingleOrDefault(x => x.LocationType == parkingTicket.LocationType);
            var canUnPark = parkingLot?.ReleaseSpot(parkingTicket.SpotNumber, parkingTicket.VehicleType);

            if (canUnPark is true)
            {
                return CreateParkingReceipt(parkingTicket);
            }
        }

        throw new NotFoundException("Invalid parking ticket");
    }

    private Ticket? CreateParkingTicket(LocationType locationType, VehicleType vehicleType, int spotNumber)
    {
        var parkingTicket = new Ticket(++_parkingTicketCounter, locationType, vehicleType);

        if (parkingTicket is not null)
        {
            parkingTicket.EntryTime = DateTime.Now;
            _parkingTickets.Add(parkingTicket);
            parkingTicket.SpotNumber = spotNumber;

            Console.WriteLine(parkingTicket);

            return parkingTicket;
        }

        return null;
    }

    private Receipt? CreateParkingReceipt(Ticket parkingTicket)
    {
        var parkingReceipt = new Receipt(++_parkingReceiptCount);

        if (parkingReceipt is not null)
        {
            var parkFee = CalculateFee(parkingTicket, parkingReceipt);
            parkingReceipt.Fees = parkFee;

            Console.WriteLine(parkingReceipt);
            _parkingReceipts.Add(parkingReceipt);

            return parkingReceipt;
        }

        return null;
    }

    private static double CalculateFee(Ticket parkingTicket, Receipt parkingReceipt)
    {
        var parkingDurationInMinutes = (parkingReceipt.ExitTime - parkingTicket.EntryTime).TotalMinutes;
        var feeFactory = new ConcreteFeeFactory().GetFee(parkingTicket.LocationType);

        var parkFee = feeFactory?.CalculateParkFee(parkingTicket.VehicleType, parkingDurationInMinutes);
        return parkFee ?? 0;
    }
}