namespace ParkingLotFeeTests;

internal class Example3StadiumParkingTests
{
    private ParkLocation _locationPark;

    [SetUp]
    public void Setup()
    {
        _locationPark = new ParkLocation();
        _locationPark.CreateParkingLots(LocationType.Stadium, 1000, 1500);
    }

    [Test]
    public void UnPark_Motorcycle_Parked3Hours40Mins_30Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Stadium, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-3).AddMinutes(-40);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(30));
    }

    [Test]
    public void UnPark_Motorcycle_Parked14Hours59Mins_390Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Stadium, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-14).AddMinutes(-59);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(390));
    }

    [Test]
    public void UnPark_SUV_Parked11Hours30Mins_180Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Stadium, VehicleType.CarOrSUV);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-11).AddMinutes(-30);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(180));
    }

    [Test]
    public void UnPark_SUV_Parked13Hours5Mins_580Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Stadium, VehicleType.CarOrSUV);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-13).AddMinutes(-5);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(580));
    }
}