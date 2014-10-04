namespace CrimeAlert.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using Model;

    public class CrimeAlertUowData : ICrimeAlertUowData
    {
        private ICrimeAlertDbContext context;
        private IDictionary<Type, object> repositories;

        public CrimeAlertUowData(ICrimeAlertDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public CrimeAlertUowData()
            : this(new CrimeAlertDbContext())
        {
        }

        public IGenericRepository<City> Cities
        {
            get { return this.GetRepository<City>(); }
        }

        public IGenericRepository<Country> Countries
        {
            get { return this.GetRepository<Country>(); }
        }

        public IGenericRepository<Crime> Crimes
        {
            get { return this.GetRepository<Crime>(); }
        }

        public IGenericRepository<CrimeType> CrimeTypes
        {
            get { return this.GetRepository<CrimeType>(); }
        }

        public IGenericRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }

        public IGenericRepository<Location> Locations
        {
            get { return this.GetRepository<Location>(); }
        }

        public IGenericRepository<Report> Reports
        {
            get { return this.GetRepository<Report>(); }
        }

        public IGenericRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
