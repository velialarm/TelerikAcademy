namespace Cars.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)] 
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
