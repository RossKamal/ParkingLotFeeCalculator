// See https://aka.ms/new-console-template for more information

var locationPark = new ParkLocation();

locationPark.CreateParkingLots(LocationType.Airport, 50, 10, 0);
locationPark.Park(LocationType.Airport, VehicleType.MotorcycleOrScooter);

locationPark.UnPark("001");
