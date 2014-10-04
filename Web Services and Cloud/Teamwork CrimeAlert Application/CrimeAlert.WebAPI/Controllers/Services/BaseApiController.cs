namespace CrimeAlert.WebAPI.Controllers
{
    using System.Net;
    using System.Web.Http;

    using CrimeAlert.Data.Repositories;
    using CrimeAlert.WebAPI.Providers;

    public abstract class BaseApiController : ApiController
    {
        protected ICrimeAlertUowData Data;
        protected IUserIdProvider UserId;
        protected BaseApiController(ICrimeAlertUowData data, IUserIdProvider userId)
        {
            this.Data = data;
            this.UserId = userId;
        }


        protected void ModelIsValid ()
        {
            if (! this.ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }


   






    }
}