namespace CrimeAlert.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        private ICollection<Report> reports;

        public Image()
        {
            this.reports = new HashSet<Report>();
        }

        public int Id { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public int ImageExtensionId { get; set; }

        public virtual ImageExtension ImageExtension { get; set; }

        public int ImageSize { get; set; }

        public string ImageMeta { get; set; }

        public virtual ICollection<Report> Reports
        {
            get { return this.reports; }
            set { this.reports = value; }
        }
    }
}
