using System.Collections.Generic;

namespace Bank.Model.Common
{
    public class Account : EntityBase
    {
        public string OwnerFullName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }
    }
}
