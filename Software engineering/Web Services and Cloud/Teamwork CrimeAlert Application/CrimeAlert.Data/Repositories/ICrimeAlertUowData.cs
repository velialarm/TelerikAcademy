namespace CrimeAlert.Data.Repositories
{
    using Model;

    public interface ICrimeAlertUowData
    {
        IGenericRepository<City> Cities { get; }

        IGenericRepository<Country> Countries { get; }

        IGenericRepository<Crime> Crimes { get; }

        IGenericRepository<CrimeType> CrimeTypes { get; }

        IGenericRepository<Image> Images { get; }

        IGenericRepository<Location> Locations { get; }

        IGenericRepository<Report> Reports { get; }

        IGenericRepository<User> Users { get; }

        void SaveChanges();
    }
}
