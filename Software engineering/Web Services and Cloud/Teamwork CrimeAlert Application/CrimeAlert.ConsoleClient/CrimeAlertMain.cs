using System.Linq;
using CrimeAlert.Data;

namespace CrimeAlert.ConsoleClient
{
    using System;
    using Data.Repositories;
    using Model;

    public class CrimeAlertMain
    {
        public static void Main()
        {

            var db = new CrimeAlertDbContext();
            db.Cities.Any();

            var data = new CrimeAlertUowData();

            var reports = new Report();
            reports.Content = "Very criminal";
            reports.Title = "Some criminal";

            var crimeType = new CrimeType();
            crimeType.Title = "Ciler";

            var location = new Location();

            location.Address = "Sofia";

            var crimes = new Crime();

            crimes.CreatedTime = DateTime.Now;
            crimes.CrimeLocation = location;
            crimes.CrimeType = crimeType;
            crimes.Reports = reports;

            data.Reports.Add(reports);

            data.CrimeTypes.Add(crimeType);

            data.Locations.Add(location);

            data.Crimes.Add(crimes);

            data.SaveChanges();
        }
    }
}
