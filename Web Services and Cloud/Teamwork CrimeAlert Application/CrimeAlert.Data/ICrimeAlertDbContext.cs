namespace CrimeAlert.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Model;

    public interface ICrimeAlertDbContext
    {
        IDbSet<City> Cities { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Crime> Crimes { get; set; }

        IDbSet<CrimeType> CrimeTypes { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<Report> Reports { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
