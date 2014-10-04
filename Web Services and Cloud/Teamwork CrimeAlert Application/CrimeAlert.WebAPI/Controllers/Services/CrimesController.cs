namespace CrimeAlert.WebAPI.Controllers.Services
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Model;
    using Data.Repositories;
    using Models.DataModels;
    using Providers;
    
    public class CrimesController : BaseApiController
    {
        public CrimesController(ICrimeAlertUowData data, IUserIdProvider userId)
            : base(data,userId)
        {
        }

        [HttpGet]
        public  IHttpActionResult AllReports()
        {
            var allCrimeReports = this.Data.Crimes.All()
                .Select(ReportCrimeModel.Report);

            if (allCrimeReports == null)
            {
                return this.BadRequest("No recorded crimes!");
            }

            return Ok(allCrimeReports);
        }


     //   [Authorize]
        [HttpPost]
        public IHttpActionResult ReportCrimes(ReportCrimeModel reportCrime)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var city = this.FindCity(reportCrime);
            var country = this.FindCountry(reportCrime);
            var userReporter = this.UserId.GetUserId();

            var reports = new Report();
            reports.Content = reportCrime.ReportContent;
            reports.Title = reportCrime.ReportTitle;

            var crimeType = new CrimeType();
            crimeType.Title = reportCrime.CrimeTypeTitle;

            var location = new Location();
            location.City = city;
            location.CityId = city.Id;
            location.City.Country = country;
            location.Address = reportCrime.Address;

            var crimes = new Crime();
            crimes.CreatedTime = DateTime.Now;
            crimes.CrimeLocation = location;
            crimes.CrimeType = crimeType;
            crimes.Reports = reports;
            //crimes.UserId = userReporter.;

            this.Data.Reports.Add(reports);
            this.Data.CrimeTypes.Add(crimeType);
            this.Data.Locations.Add(location);
            this.Data.Crimes.Add(crimes);
            crimes.Id = reportCrime.Id;

            this.Data.SaveChanges();

            return Ok(crimes.Id);
        }

        [Authorize]
        [HttpDelete]
        public  IHttpActionResult DeleteReport (int id )
        {
            if (id == null || id < 0)
            {
                return this.BadRequest("The parametar Id must be to bigger from zero");
            }

            var findReport = this.Data.Crimes.FindById(id);
            if (findReport == null )
            {
                return this.BadRequest("Can`t find crimes whit this id !");
            }

//            var currentUserID = this.UserId.GetUserId();
//            if (findReport.UserId != currentUserID)
//            {
//                return this.BadRequest("You can not delete this Report!");
//            }

            this.Data.Crimes.Delete(findReport);
            this.Data.SaveChanges();

            return Ok("Crimes is deleted !");
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Update(int id, ReportCrimeModel reportCrime)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            
//            var userID = this.UserId.GetUserId();
            var updateCrime = this.Data.Crimes.FindById(id);
//            if (updateCrime.UserId != userID)
//            {
//                return this.BadRequest("You can`t update this crimes !");
//            }


            if (updateCrime == null)
            {
                return this.BadRequest("Can`t find crimes with this id!");
            }

            // find Report by id and set new changes
            var updateReport = this.Data.Reports.SearchFor(x => x.Id == updateCrime.ReportId).FirstOrDefault();
            updateReport.Content = reportCrime.ReportContent;
            updateReport.Title = reportCrime.ReportTitle;

            if (updateCrime == null)
            {
                return this.BadRequest("Can`t find report with this id!");
            }

            // find CrimeType by id and set new changes
            var updateCrimeType = this.Data.CrimeTypes.FindById(updateCrime.CrimeTypeId);
            updateCrimeType.Title = reportCrime.CrimeTypeTitle;

            if (updateCrime == null)
            {
                return this.BadRequest("Can`t find CrimeType with this id!");
            }

            // find Location by id and set new changes
            var updateLocation = this.Data.Locations.FindById(updateCrime.CrimeLocationId);
            updateLocation.Address = reportCrime.Address;

            if (updateCrime == null)
            {
                return this.BadRequest("Can`t find Location with this id!");
            }

            // find City by id and set new changes
            var updateCity = this.Data.Cities.FindById(updateLocation.CityId);
            updateCity.Name = reportCrime.CityName;

            if (updateCrime == null)
            {
                return this.BadRequest("Can`t find City with this id!");
            }

            // find Country by id and set new changes
            var updateCountry = this.Data.Countries.FindById(updateCity.CountryId);
            updateCountry.Name = reportCrime.CountryName;

            if (updateCrime == null)
            {
                return this.BadRequest("Can`t find Country with this id!");
            }

            // Update tables
            this.Data.Reports.Update(updateReport);
            this.Data.CrimeTypes.Update(updateCrimeType);
            this.Data.Locations.Update(updateLocation);
            this.Data.Cities.Update(updateCity);
            this.Data.Countries.Update(updateCountry);

            updateCrime.Id = id;

            this.Data.SaveChanges();

            return Ok(updateCrime.Id);
        }



        private Country FindCountry(ReportCrimeModel reportCrime)
        {
            var country = this.Data.Countries
                .SearchFor(x => x.Name == reportCrime.CountryName)
                .FirstOrDefault();

            if (country == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return country;
        }

        private City FindCity(ReportCrimeModel reportCrime)
        {
            var city = this.Data.Cities.SearchFor(x => x.Name == reportCrime.CityName).FirstOrDefault();

            if (city == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return city;
        }
    }
}