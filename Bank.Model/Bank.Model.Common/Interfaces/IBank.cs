using Bank.Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common.Interfaces
{
    public interface IBank
    {
        List<AccountModel> GetAccounts();
        void AddAccount(AccountModel account);
        void Login();
        void CreateAccount();
        void Start();
    }
}
