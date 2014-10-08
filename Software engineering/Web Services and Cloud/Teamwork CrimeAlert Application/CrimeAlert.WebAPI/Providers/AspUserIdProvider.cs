namespace CrimeAlert.WebAPI.Providers
{
    using System.Threading;
    using Microsoft.AspNet.Identity;

    public class AspUserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}