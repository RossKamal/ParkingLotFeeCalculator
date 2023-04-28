namespace ParkingLotFeeTests;

public class Example2MallParkingTests
{
    private ParkLocation _locationPark;

    [SetUp]
    public void Setup()
    {
        _locationPark = new ParkLocation();
        _locationPark.CreateParkingLots(LocationType.Mall, 100, 80, 10);
    }

    [Test]
    public void UnPark_Motorcycle_Parked3Hours30Mins_40Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Mall, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-3).AddMinutes(-30);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(40));
    }

    [Test]
    public void UnPark_Car_Parked6Hours1Mins_140Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Mall, VehicleType.CarOrSUV);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-6).AddMinutes(-1);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(140));
    }

    [Test]
    public void UnPark_Truck_Parked1Hours59Mins_100Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Mall, VehicleType.BusOrTruck);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-1).AddMinutes(-59);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(100));
    }
}