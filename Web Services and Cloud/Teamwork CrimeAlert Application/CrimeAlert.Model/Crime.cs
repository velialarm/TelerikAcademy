namespace CrimeAlert.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Crime
    {
        public int Id { get; set; }

        [Required]
//        [Column("CRIME_TYPE_ID")]
        public int CrimeTypeId { get; set; }

        public virtual CrimeType CrimeType { get; set; }

//        [Required]
//        [Column("REPORT_ID")]
        public int? ReportId { get; set; }

        public virtual Report Reports { get; set; }

        [Required]
//        [Column("CRIME_LOCATION_ID")]
        public int CrimeLocationId { get; set; }

        public virtual Location CrimeLocation { get; set; }

        public DateTime CreatedTime { get; set; }

        ////[Required]
//        [Column("USERA_ID")]
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
