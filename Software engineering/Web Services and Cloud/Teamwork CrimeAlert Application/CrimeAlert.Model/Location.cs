namespace CrimeAlert.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Location
    {
        private ICollection<Crime> crimes;

        public Location()
        {
            this.crimes = new HashSet<Crime>();
        }

        [Key]
        public int Id { get; set; }

////        [Required]
////        [Index(IsUnique = true)]
        [MaxLength(20)]
        [MinLength(3)]
        public string Address { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        //// TODO add GPS coordinates

        public virtual ICollection<Crime> Crimes
        {
            get { return this.crimes; }
            set { this.crimes = value; }
        }
    }
}
