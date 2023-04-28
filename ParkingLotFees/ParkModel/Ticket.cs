namespace ParkingLotFeeCalculator.ParkModel
{
    public record Ticket
    {
        private readonly int _counter;

        public int SpotNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public LocationType LocationType { get; internal set; }
        public VehicleType VehicleType { get; internal set; }

        public Ticket(int counter, LocationType locationType, VehicleType vehicleType)
        {
            LocationType = locationType;
            VehicleType = vehicleType;
            _counter = counter;
        }

        public string Number
        {
            get => _counter.ToString("D3");
        }
    }
}