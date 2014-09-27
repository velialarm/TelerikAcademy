using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data.Migrations;
using ATM.Model;

namespace ATM.Data
{
    public class ATMContextDb : DbContext
    {
        public ATMContextDb() : base("AtmMashine")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContextDb, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionsHistory> TransactionsHistories { get; set; }
    }

}
