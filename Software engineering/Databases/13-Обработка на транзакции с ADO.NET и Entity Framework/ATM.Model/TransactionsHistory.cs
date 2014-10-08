using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    public class TransactionsHistory
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Ammount { get; set; }

        public int CardAccountId { get; set; }

        private CardAccount cardAccount;

        public virtual CardAccount CardAccount
        {
            get { return this.cardAccount; }
            set { this.cardAccount = value; }
        }
    }
}
