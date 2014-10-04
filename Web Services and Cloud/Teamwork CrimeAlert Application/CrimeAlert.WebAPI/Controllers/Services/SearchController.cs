namespace CrimeAlert.WebAPI.Controllers.Services
{
    using System.Linq;
    using System.Web.Http;

    using CrimeAlert.Data.Repositories;
    using CrimeAlert.WebAPI.Models.DataModels;
    using CrimeAlert.WebAPI.Providers;
    

    public class SearchController : BaseApiController
    {

        public SearchController(ICrimeAlertUowData data, IUserIdProvider userId)
            : base(data,userId)
        {

        }

        [HttpGet]
        public IHttpActionResult AllReports()
        {

            var allCrimeReports = this.Data.Crimes.All()
                .Select(ReportCrimeModel.Report);

            if (allCrimeReports == null)
            {
                return this.BadRequest("No recorded crimes!");
            }

            return Ok(allCrimeReports);
        }


        [HttpGet]
        public IHttpActionResult SearchReports(string country)
        {

            var reportIncountry = this.Data.Crimes
                .SearchFor(x => x.CrimeLocation.City.Country.Name == country)
                .Select(ReportCrimeModel.Report)
                .OrderBy(c => c.Address);

            if (reportIncountry == null )
            {
                return this.BadRequest("No reports in this country");
            }


            return Ok(reportIncountry);
        }

        [HttpGet]
        public IHttpActionResult SearchReports(string country, string city)
        {
            var reportByAddress = this.Data.Crimes
                .SearchFor(x =>
                    x.CrimeLocation.City.Country.Name == country
                    && x.CrimeLocation.City.Name == city)
                .Select(ReportCrimeModel.Report)
                .OrderBy(o => o.Address);

            if (reportByAddress == null)
            {
                return this.BadRequest("No reports in this city ");
            }

            return Ok(reportByAddress);
        }

        [HttpGet]
        public IHttpActionResult SearchReports(string country, string city, string address)
        {

            var serchCrime = this.Data.Crimes.SearchFor(x =>
                    x.CrimeLocation.City.Country.Name == country
                    && x.CrimeLocation.City.Name == city
                    && x.CrimeLocation.Address == address)
                .Select(ReportCrimeModel.Report)
                .OrderBy(o => o.Address);


            if (serchCrime == null)
            {
                return this.BadRequest("No reports in this address");
            }


            return Ok(serchCrime);
        }


    }
}