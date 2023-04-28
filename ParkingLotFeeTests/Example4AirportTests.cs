namespace ParkingLotFeeTests;

internal class Example4AirportTests
{
    private ParkLocation _locationPark;

    [SetUp]
    public void Setup()
    {
        _locationPark = new ParkLocation();
        _locationPark.CreateParkingLots(LocationType.Airport, 200, 500, 100);
    }

    [Test]
    public void UnPark_Motorcycle_Parked55Mins_0Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Airport, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddMinutes(-55);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(0));
    }

    [Test]
    public void UnPark_Motorcycle_Parked14Hours59Mins_60Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Airport, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-14).AddMinutes(-59);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(60));
    }

    [Test]
    public void UnPark_Motorcycle_Parked1Day12Hours_160Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Airport, VehicleType.MotorcycleOrScooter);
        parkingTicket.EntryTime = DateTime.Now.AddDays(-1).AddHours(-12);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(160));
    }

    [Test]
    public void UnPark_Car_Parked50Mins_60Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Airport, VehicleType.CarOrSUV);
        parkingTicket.EntryTime = DateTime.Now.AddMinutes(-50);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(60));
    }

    [Test]
    public void UnPark_Car_Parked23Hours59Mins_80Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Airport, VehicleType.CarOrSUV);
        parkingTicket.EntryTime = DateTime.Now.AddHours(-23).AddMinutes(-50);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(80));
    }

    [Test]
    public void UnPark_Car_Parked3Days1hour_400Fee()
    {
        var parkingTickets = new List<Ticket>();
        var parkingReceipts = new List<Receipt>();

        var parkingTicket = _locationPark.Park(LocationType.Airport, VehicleType.CarOrSUV);
        parkingTicket.EntryTime = DateTime.Now.AddDays(-3).AddHours(-1);
        parkingTickets.Add(parkingTicket);

        var parkingReceipt = _locationPark.UnPark("001");
        parkingReceipts.Add(parkingReceipt);

        Assert.That(parkingReceipts[0].Fees, Is.EqualTo(400));
    }
}