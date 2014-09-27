using Nortwind.Data;

namespace Nortwind.Client
{
    /// <summary>
    /// 2. Task
    /// Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
    /// </summary>
    public static class CustomerDAO
    {
        public static void Add(Customer customer)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public static void Update(Customer oldCustomer, Customer newCustomer)
        {
            using (var db = new NorthwindEntities())
            {
                var customer = db.Customers.Find(oldCustomer.CustomerID);
                customer.Address = newCustomer.Address;
                customer.City = newCustomer.City;
                customer.CompanyName = newCustomer.CompanyName;
                customer.ContactName = newCustomer.ContactName;
                customer.ContactTitle = newCustomer.ContactTitle;
                customer.Country = newCustomer.Country;
                customer.CustomerDemographics = newCustomer.CustomerDemographics;
                customer.Fax = newCustomer.Fax;
                customer.Orders = newCustomer.Orders;
                customer.Phone = newCustomer.Phone;
                customer.PostalCode = newCustomer.PostalCode;
                customer.Region = newCustomer.Region;
                db.SaveChanges();
            }
        }

        public static void Delete(Customer customer)
        {
            using (var db = new NorthwindEntities())
            {
                var cust = db.Customers.Find(customer.CustomerID);
                db.Customers.Remove(cust);
                db.SaveChanges();
            }
        }
    }
}