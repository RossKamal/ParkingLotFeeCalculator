namespace ParkingLotFeeTests;

public class LocationParkTests
{
    private ParkLocation _locationPark;

    [SetUp]
    public void Setup()
    {
        _locationPark = new ParkLocation();
    }

    [Test]
    public void CreateParkingLots_CheckLocationType()
    {
        //Arrange
        var parkingLots = _locationPark.CreateParkingLots(LocationType.Mall, 50, 50, 0);

        //Act
        var parkingLot = parkingLots.First(x => x.LocationType.Equals(LocationType.Mall));

        //Assert
        Assert.That(parkingLot.LocationType, Is.EqualTo(LocationType.Mall));
    }

    [Test]
    public void Park_ValidCarParking()
    {
        _locationPark.CreateParkingLots(LocationType.Mall, 50, 50, 0);

        var parkingTicket = _locationPark.Park(LocationType.Mall, VehicleType.CarOrSUV);

        Assert.That(parkingTicket?.Number, Is.EqualTo("001"));
    }

    [Test]
    public void Park_InValidBusParking_ThrowNoSpace()
    {
        _locationPark.CreateParkingLots(LocationType.Mall, 50, 50, 0);

        var exception = Assert.Throws<NotFoundException>(()
            => _locationPark.Park(LocationType.Mall, VehicleType.BusOrTruck));
        Assert.That(exception?.Message, Is.EqualTo("No space available"));
    }

    [Test]
    public void UnPark_ValidCarUnParking()
    {
        _locationPark.CreateParkingLots(LocationType.Mall, 50, 50, 0);

        _locationPark.Park(LocationType.Mall, VehicleType.CarOrSUV);

        var parkingReceipt = _locationPark.UnPark("001");
        Assert.That(parkingReceipt?.Number, Is.EqualTo("R - 001"));
    }

    [Test]
    public void UnPark_InValidBusParking_ThrowNoSpace()
    {
        _locationPark.CreateParkingLots(LocationType.Mall, 50, 50, 0);

        _locationPark.Park(LocationType.Mall, VehicleType.CarOrSUV);

        var exception = Assert.Throws<NotFoundException>(()
            => _locationPark.UnPark("002"));
        Assert.That(exception?.Message, Is.EqualTo("Invalid parking ticket"));
    }
}