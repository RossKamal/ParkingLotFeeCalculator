namespace ParkingLotFeeCalculator.ParkModel
{
    public record Receipt
    {
        private readonly int _counter;

        public string Number { get => "R - " + _counter.ToString("D3"); }
        public DateTime ExitTime { get; set; }
        public double Fees { get; set; }

        public Receipt(int counter)
        {
            _counter = counter;
            ExitTime = DateTime.Now;
        }
    }
}