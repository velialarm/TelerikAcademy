namespace CrimeAlert.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CrimeAlertDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "CrimeAlert.Data.CrimeAlertContext";
        }

        protected override void Seed(CrimeAlertDbContext context)
        {
        }
    }
}
