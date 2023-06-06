using Bank.Model.Common;
using System.Collections.Generic;


namespace Bank.Model
{
    public class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}
