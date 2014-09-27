namespace Cars.Data
{
    using System.Data.Entity;
    using Migrations;
    using Model;

    public class CarsContext : DbContext
    {
        public CarsContext()
            : base("CarsConnection")
        {
            //// Migration Strategy
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<City> Cities { get; set; }
    }
}
