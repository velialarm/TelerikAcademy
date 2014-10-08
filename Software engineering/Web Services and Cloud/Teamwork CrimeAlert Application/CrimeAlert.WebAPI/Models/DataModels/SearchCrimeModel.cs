

using System.ComponentModel.DataAnnotations;
namespace CrimeAlert.WebAPI.Models.DataModels
{
    public class SearchCrimeModel
    {

        [Required]
        [Display(Name = "Country")]
        [MaxLength(20, ErrorMessage = "Country name must be 20 characters or less")]
        [MinLength(3, ErrorMessage = "Report Title must be to bigger from 3 characters")]
        public string CountryName { get; set; }

        [Required]
        [Display(Name = "City")]
        [MaxLength(20, ErrorMessage = "City name must be 20 characters or less")]
        [MinLength(3, ErrorMessage = "Report Title must be to bigger from 3 characters")]
        public string CityName { get; set; }


        [Required]
        [Display(Name = "Address")]
        [MaxLength(20, ErrorMessage = "Address must be 20 characters or less")]
        [MinLength(3, ErrorMessage = "Address must be to bigger from 3 characters")]
        public string AddressName { get; set; }
    }
}