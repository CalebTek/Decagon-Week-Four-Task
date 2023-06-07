using Bank.Model.Common.Models;

namespace Bank.Model.Common.Interfaces
{
    public interface IAccount
    {
        void Deposit(AccountModel aacount);

        void Withdraw(AccountModel account);

        void Transfer(IBank bank, AccountModel senderAccount);


    }
}
