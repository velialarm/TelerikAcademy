using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Nortwind.Data;
using System.Transactions;

namespace Nortwind.Client
{
    class StartupClient
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                CustomerID = "1",
                Address = "Mainata address 1",
                City = "Plovdiv",
                CompanyName = "TestComp",
                ContactName = "Pesho",
                ContactTitle = "Manager",
                Country = "Bulgaria",
                Phone = "0000000000",
                PostalCode = "00000"
            };

            CustomerDAO.Update(new Customer { CustomerID = "WOLZA" }, customer);

            //3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada
            FindCustimers(1997, "Canada");
            Console.WriteLine();

            //4. Implement previous by using native SQL query and executing it through the DbContext
            FindCustomersSqlQuery(1997, "Canada");

            //5. Write a method that finds all the sales by specified region and period (start / end dates).
            Console.WriteLine(Environment.NewLine + "Orders:");
            FindSalesByRegionAndPeriod("SP", new DateTime(1997, 6, 25), new DateTime(1998, 6, 25));

            //6. Create a database called NorthwindTwin with the same structure as Northwind
            string nortwindOriginalSql = @"..\..\..\NorthwindEntity.Data\Northwind.edmx.sql";
            CreateNorthwindTwinDatabase(nortwindOriginalSql);

            //7. Open two different data contexts
            OpenTwoContexts();

            // 9. Places a new order in the Northwind database
            Order order = new Order{
                CustomerID = "BLONP",
                OrderDate = DateTime.Now,
                ShipCountry = "Bulgaria",
                ShipName = "Last ship"
            };
            Order_Detail orderDetail = new Order_Detail
            {
                ProductID = 5,
                Quantity = 10,
                Discount = 0
            };
            AddOrder(order, orderDetail);

            // 10. Create a stored procedures in the Northwind database
            GetIncomeBySupplierAndPeriod();

            //11. Create a transactional EF based method that creates an user and puts it in a group "Admins"
            UserGroupsTransaction();

        }

        /// <summary>
        /// 3. Task
        /// Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        private static void FindCustimers(int year, string country)
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.Join(db.Orders,
                    (c => c.CustomerID),
                    (o => o.CustomerID),
                    (c, o) => new
                    {
                        Customer = c.ContactName,
                        ShipCountry = o.ShipCountry,
                        OrderDate = o.OrderDate
                    }).Where(o => o.ShipCountry == country && o.OrderDate.Value.Year == year);

                //var customers =
                //    from customer in context.Customers
                //    join order in context.Orders
                //    on customer.CustomerID equals order.CustomerID
                //    where order.ShipCountry == country && order.OrderDate.Value.Year == year
                //    select customer.ContactName;


                foreach (var customer in customers)
                {
                    Console.WriteLine("Name: {0}", customer.Customer);
                }
            }
        }

        /// <summary>
        /// 4. Task
        /// Implement previous by using native SQL query and executing it through the DbContext.
        /// </summary>
        private static void FindCustomersSqlQuery(int year, string country)
        {
            using (var context = new NorthwindEntities())
            {
                string query =
                    "SELECT ContactName FROM Customers c " +
                    "JOIN Orders o ON c.CustomerId = o.CustomerId " +
                    "WHERE o.ShipCountry = {0} AND YEAR(o.OrderDate) = {1}";
                object[] parameters = { country, year };
                var customers = context.Database.SqlQuery<string>(query, parameters);

                foreach (var customer in customers)
                {
                    Console.WriteLine("Name: {0}", customer);
                }
            }
        }

        /// <summary>
        /// 5. Task
        /// Write a method that finds all the sales by specified region and period (start / end dates).
        /// </summary>
        private static void FindSalesByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            using (var db = new NorthwindEntities())
            {
                var orders = db.Orders
                    .Where(x => x.ShipRegion == region && x.OrderDate > startDate && x.OrderDate < endDate)
                    .Select(x => x.ShipName);

                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
        }
        /// <summary>
        /// 6. Task
        /// Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. 
        /// Find for the API for schema generation in MSDN or in Google.
        /// </summary>
        private static void CreateNorthwindTwinDatabase(string originalDataBaseSql)
        {
            //@"..\..\..\NorthwindEntity.Data\Northwind.edmx.sql"
            StreamReader reader = new StreamReader(originalDataBaseSql);
            string query = string.Empty;
            using (reader)
            {
                query = reader.ReadToEnd();
            }

            Console.WriteLine(query);
        }

        /// <summary>
        /// 7. Task
        /// Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()? How to deal with it?
        /// </summary>
        private static void OpenTwoContexts()
        {
            var context = new NorthwindEntities();
            var context2 = new NorthwindEntities();

            using (context)
            {
                using (context2)
                {
                    Customer customer1 = context.Customers.Find("BLAUS");
                    Customer customer2 = context2.Customers.Find("BLAUS");

                    customer1.City = "Plovdiv";
                    customer2.City = "Varna";

                    context2.SaveChanges();
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 9. Task
        /// Create a method that places a new order in the Northwind database. 
        /// The order should contain several order items. 
        /// Use transaction to ensure the data consistency.
        /// </summary>
        public static void AddOrder(Order order, Order_Detail orderDetail)
        {
            using (var context = new NorthwindEntities())
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                    orderDetail.OrderID = context.Orders.Where(x => x.ShipName == "Last ship").First().OrderID;
                    context.Order_Details.Add(orderDetail);
                    context.SaveChanges();

                    transaction.Complete();
                }
            }
        }

        /// <summary>
        /// 10. Task
        /// Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period (start date, end date). 
        /// Implement a C# method that calls the stored procedure and returns the retuned record set.
        /// </summary>
        public static void GetIncomeBySupplierAndPeriod()
        {
            NorthwindEntities northwindDbContex = new NorthwindEntities();

            using (northwindDbContex)
            {
                northwindDbContex.Database.ExecuteSqlCommand("CREATE PROCEDURE usp_GetIncomeByGivenCompany " +
                "@companyName nvarchar(60), @startDate date, @endDate date AS " +
                "SELECT s.CompanyName, SUM(od.UnitPrice * od.Quantity) AS Income " +
                "FROM Suppliers s " +
                "JOIN Products p " +
                "ON s.SupplierID = p.SupplierID " +
                "JOIN [Order Details] od " +
                "ON p.ProductID = od.ProductID " +
                "JOIN Orders o " +
                "ON od.OrderID = o.OrderID " +
                "where o.ShippedDate > @startDate AND o.ShippedDate < @endDate " +
                "AND s.CompanyName = @companyName " +
                "GROUP BY s.CompanyName");

                string companyName = "Exotic Liquids";
                DateTime startDate = new DateTime(1990, 1, 1);
                DateTime endDate = new DateTime(1999, 1, 1);


                //TODO 
//                var col = northwindDbContex.usp_GetIncomeByGivenCompany(companyName, startDate, endDate).First();
//                Console.WriteLine("Company name: {0} -> Income: {1}", col.CompanyName, col.Income);
            }
        }

        /// <summary>
        /// 11. Task
        /// Create a database holding users and groups. Create a transactional EF based method that creates an user and puts it in a group "Admins". 
        /// In case the group "Admins" do not exist, create the group in the same transaction. 
        /// If some of the operations fail (e.g. the username already exist), cancel the entire transaction.
        /// </summary>
        public static void UserGroupsTransaction()
        {
            using (var userContex = new NorthwindEntities())
            {
                using (var dbContextTransaction = userContex.Database.BeginTransaction())
                {
                    try
                    {
                        //TODO to test must import extend database !!!
//                        Group adminGroup = new Group { GroupId = 2, GroupName = "Admins" };
//
//                        if (userContex.Groups.Where(g => g.GroupName == "Admins").ToList().Count == 0)
//                        {
//                            userContex.Groups.Add(adminGroup);
//                            userContex.SaveChanges();
//                        }
//
//                        User user = new User { UserId = 1, UserName = "Pesho", Password = "1234", GroupId = 2 };
//
//                        userContex.Users.Add(user);
//                        userContex.SaveChanges();
//                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
