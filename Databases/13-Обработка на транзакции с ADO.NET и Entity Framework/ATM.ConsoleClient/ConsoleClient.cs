using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ATM.Data;
using ATM.Model;

namespace ATM.ConsoleClient
{
    class ConsoleClient
    {
        static void Main(string[] args)
        {
            AddCardAccount();

            RetrieveMoney(200); // this is default
        }

        public static CardAccount AddCardAccount()
        {
            CardAccount acount = null;
            using (var db = new ATMContextDb())
            {
                acount = new CardAccount
                {
                    CardCash = GenerateRandomCash(200, 4000),
                    CardNumber = GenerateRandomNumber(10),
                    CardPIN = GenerateRandomNumber(4)
                };
                db.CardAccounts.Add(acount);
                db.SaveChanges();
            }
            return acount;
        }

        /// <summary>
        /// 2. Task
        /// Using transactions write a method which retrieves some money (for example$200)from certain account. 
        /// The retrieval is successful when the following sequence of sub-operations is completed successfully:
        ///     - A query checks if the givenCardPINand CardNumberare valid.
        ///     - The amount onthe account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than$200).
        ///     - The ATM machine pays the required sum(e.g. $200) and stores in the tableCardAccountsthe new amount(CardCash=CardCash-200).
        /// </summary>
        public static void RetrieveMoney(decimal money)
        {
            CardAccount acount = AddCardAccount();

            using (var db = new ATMContextDb())
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    db.CardAccounts.Attach(acount);
                    bool hasDraw = acount.DrawMoney(money);
                    if (hasDraw)
                    {
                        // create transaction
                        var tran = new TransactionsHistory
                        {
                            CardAccount = acount,
                            TransactionDate = DateTime.Now,
                            CardNumber = acount.CardNumber,
                            CardAccountId = acount.Id,
                            Ammount = acount.CardCash
                        };
                        db.TransactionsHistories.Add(tran);
                        db.SaveChanges();
                    }
                }
            }
        }

        private static string GenerateRandomNumber(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder(10);
            while (length > 0)
            {
                int nextNumber = random.Next(48, 90);
                if (58 <= nextNumber && nextNumber <= 64)
                {
                    continue;
                }
                char c = (char)nextNumber;
                sb.Append(c);
                length--;
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        private static decimal GenerateRandomCash(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
