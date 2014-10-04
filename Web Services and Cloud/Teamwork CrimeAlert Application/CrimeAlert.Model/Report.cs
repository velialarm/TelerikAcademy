namespace CrimeAlert.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Report
    {
        private ICollection<Crime> crimes;
        private ICollection<Image> images;

        public Report()
        {
            this.images = new HashSet<Image>();
            this.crimes = new HashSet<Crime>();
        }

        [Key]
        public int Id { get; set; }

////        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }

//        [Required]
        [MaxLength(200)]
//        [MinLength(20)]
        [Column(TypeName = "TEXT")]
        public string Content { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Crime> Crimes
        {
            get { return this.crimes; }
            set { this.crimes = value; }
        }
    }
}
