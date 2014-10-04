namespace CrimeAlert.WebAPI.Models.DataModels
{
    using System;
    using System.Linq.Expressions;
    using CrimeAlert.Model;
    using System.ComponentModel.DataAnnotations;

    public class ReportCrimeModel
    {
        public static Expression<Func<Crime, ReportCrimeModel>> Report
        {
            get
            {
                return crimeReport => new ReportCrimeModel
                {
                    Id = crimeReport.Id,
                    Address = crimeReport.CrimeLocation.Address,
                    ReportContent = crimeReport.Reports.Content,
                    ReportTitle = crimeReport.Reports.Title,
                    CrimeTypeTitle = crimeReport.CrimeType.Title,
                    CountryName = crimeReport.CrimeLocation.City.Country.Name,
                    CityName = crimeReport.CrimeLocation.City.Name,
                };
            }
        }

        
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Report Title must be 20 characters or less")]
        [MinLength(5, ErrorMessage = "Report Title must be to bigger from 5 characters")]
        public string ReportTitle { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Report Content must be 100 characters or less")]
        [MinLength(20, ErrorMessage = "Report Content must be to bigger from 20 characters")]
        public string ReportContent { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Crime type title must be 20 characters or less")]
        [MinLength(5, ErrorMessage = "Crime type title must be to bigger from 5 characters")]
        public string CrimeTypeTitle { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Address must be 20 characters or less")]
        [MinLength(3, ErrorMessage = "Address must be to bigger from 3 characters")]
        public string Address { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Country name must be 20 characters or less")]
        [MinLength(3, ErrorMessage = "Report Title must be to bigger from 3 characters")]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "City name must be 20 characters or less")]
        [MinLength(3, ErrorMessage = "Report Title must be to bigger from 3 characters")]
        public string CityName { get; set; }
    }
}