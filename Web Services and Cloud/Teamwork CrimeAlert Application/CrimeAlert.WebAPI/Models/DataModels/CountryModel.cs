namespace CrimeAlert.WebAPI.Models.DataModels
{
    using CrimeAlert.Model;
    using System;
    using System.Linq.Expressions;

    public class CountryModel
    {
        public static Expression<Func<Country, CountryModel>> GetCountry
        {
            get
            {
                return coutry => new CountryModel
                {
                    Id = coutry.Id,
                    Name = coutry.Name,
                };
            }
        }


        public int Id { get; set; }

        public string Name { get; set; }


    }
}