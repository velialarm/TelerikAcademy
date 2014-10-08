namespace Cars.Client
{
    using Container;

    public class CarContainer
    {
        public string Year { get; set; }

        public string TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerContainer Dealer { get; set; }
    }
}
