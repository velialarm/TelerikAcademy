namespace CrimeAlert.WebAPI.Controllers.Services
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
   
    using CrimeAlert.Model;
    using CrimeAlert.WebAPI.Models.DataModels;
    using CrimeAlert.Data.Repositories;
    using CrimeAlert.WebAPI.Providers;
  
    [Authorize]
    public class CountriesController : BaseApiController
    {

        public CountriesController(ICrimeAlertUowData data, IUserIdProvider userId)
            : base(data,userId )
            
        {

        }

        [HttpGet]
        public  System.Web.Http.IHttpActionResult All()
        {

            var all = this.Data.Countries.All()
                .Select(CountryModel.GetCountry);

            return Ok(all);
        }

        [HttpGet]
        public  System.Web.Http.IHttpActionResult FindById(int id)
        {
            var find = this.Data.Countries.All()
                .Where(x => x.Id == id)
                .Select(CountryModel.GetCountry)
                .FirstOrDefault();


            return Ok(find);
        }

        [HttpDelete]
        public  System.Web.Http.IHttpActionResult Delete(int id)
        {
            var findCoutry = this.GetId(id);

            this.Data.Countries.Delete(findCoutry);

            this.Data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Add(CountryModel country)
        {
            this.ModelIsValid();

            var addCountry = new Country();

            addCountry.Name = country.Name;

            this.Data.Countries.Add(addCountry);

            this.Data.SaveChanges();
            addCountry.Id = country.Id;

            return Ok();
        }


        private Country GetId (int id)
        {

            var getId = this.Data.Countries.FindById(id);

            if (getId == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return getId;
        }

    }
}