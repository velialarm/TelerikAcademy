namespace CrimeAlert.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Model;

    public class CrimeAlertDbContext : IdentityDbContext<User>, ICrimeAlertDbContext
    {
        public CrimeAlertDbContext()
            : base("CrimeAlertConnection")
        {
            //// Migration Strategy
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrimeAlertDbContext, Configuration>());
        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Crime> Crimes { get; set; }

        public IDbSet<CrimeType> CrimeTypes { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Report> Reports { get; set; }

        public static CrimeAlertDbContext Create()
        {
            return new CrimeAlertDbContext();
        }
    
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges(){
            base.SaveChanges();
        }
    }
}
