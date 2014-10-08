namespace Conflux.Data
{
    using System.Data.Entity;
    using Migrations;
    using Model;

    public class ConfluxEntities : DbContext
    {
        public ConfluxEntities()
            : base("ConfluxTeam")
        {
            //// Migration Strategy
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConfluxEntities, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Currency> Currencies { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<VendorType> VendorTypes { get; set; }
    }
}
