using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    /// <summary>
    /// 1. Task 
    /// Suppose you are creating a simple engine for an ATM machine. 
    /// Create a new database "ATM"inSQL Server to hold the accounts of the card holders and the balance (money) for each account. Add a new tableCardAccountswith the following fields: 
    ///     - Id(int)
    ///     - CardNumber(char(10))
    ///     - CardPIN(char(4))
    ///     - CardCash(money)
    /// Add a few sample records in the table.
    /// </summary>
    public class CardAccount
    {
        private const int CardNumberLength = 10;
        private const int CardPinLength = 4;

        private ICollection<TransactionsHistory> transactionsHistories;

        public CardAccount()
        {
            this.transactionsHistories = new HashSet<TransactionsHistory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(CardNumberLength)]
        [Index(IsUnique = true)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(CardPinLength)]
        public string CardPIN { get; set; }

        public virtual ICollection<TransactionsHistory> TransactionsHistories
        {
            get { return transactionsHistories; }
            set { transactionsHistories = value; }
        }

        public decimal CardCash { get; set; }

        public bool IsValidCardNumber()
        {
            return !string.IsNullOrEmpty(CardNumber) && CardNumber.Trim().Length == CardNumberLength;
        }

        public bool IsValidCardPin()
        {
            return !string.IsNullOrEmpty(CardPIN) && CardPIN.Trim().Length == CardPinLength;
        }

        private bool IsPermittedWithdrawalAmount(decimal withdrawalAmount)
        {
            var isPermittedWithdrawalAmount = withdrawalAmount > 0 && CardCash >= withdrawalAmount;
            return isPermittedWithdrawalAmount;
        }

        public bool DrawMoney(decimal drawMoney)
        {
            if (IsPermittedWithdrawalAmount(drawMoney))
            {
                CardCash -= drawMoney;
                return true;
            }
            return false;
        }
    }
}
