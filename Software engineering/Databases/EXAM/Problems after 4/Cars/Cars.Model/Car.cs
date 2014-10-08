namespace Cars.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmisionType TransmisionType { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
