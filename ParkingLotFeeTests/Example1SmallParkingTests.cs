namespace ParkingLotFeeTests;

public class Example1SmallParkingTests
{
    private ParkLocation _locationPark;
    private List<Ticket> _parkingTickets;

    [SetUp]
    public void Setup()
    {
        _locationPark = new ParkLocation();
        _locationPark.CreateParkingLots(LocationType.Mall, 2);
        _parkingTickets = Park2Motorcycle();
    }

    private List<Ticket> Park2Motorcycle()
    {
        List<Ticket> parkingTickets = new();
        var parkingTicket = _locationPark.Park(LocationType.Mall, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-3);
        parkingTickets.Add(parkingTicket);

        var parkingTicket1 = _locationPark.Park(LocationType.Mall, VehicleType.MotorcycleOrScooter);
        parkingTicket1.EntryTime = DateTime.Now.AddMinutes(-40);
        parkingTickets.Add(parkingTicket1);

        return parkingTickets;
    }

    [Test]
    public void Park_Try3rdMotorcyclePark_FailOnMaxCapacity()
    {
        var exception = Assert.Throws<NotFoundException>(()
            => _locationPark.Park(LocationType.Mall, VehicleType.MotorcycleOrScooter));

        Assert.That(_parkingTickets[0].Number, Is.EqualTo("001"));
        Assert.That(_parkingTickets[1].Number, Is.EqualTo("002"));
        Assert.That(exception?.Message, Is.EqualTo("No space available"));
    }

    [Test]
    public void UnPark_CalculateFee()
    {
        var parkingReceipts = new List<Receipt>();
        var parkingReceipt = _locationPark.UnPark("002");
        parkingReceipts.Add(parkingReceipt);

        var parkingReceipt1 = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt1);


        Assert.That(parkingReceipts[0].Number, Is.EqualTo("R - 001"));
        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(10));

        Assert.That(parkingReceipts[1].Number, Is.EqualTo("R - 002"));
        Assert.That(parkingReceipts[1].Fees, Is.EqualTo(40));
    }
}