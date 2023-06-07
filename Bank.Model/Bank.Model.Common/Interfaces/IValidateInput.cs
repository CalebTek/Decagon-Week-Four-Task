using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Model.Common.Interfaces
{
    public interface IValidateInput
    {
        int GetChoice(int max);
        int GetChoice(int min, int max);
        string GetAccountNumber();
        string GetPassword();
        bool IsValidPassword(string password);
        string GetFullName();
        bool IsValidFullName(string fullName);
        decimal GetAmount(string prompt);
        string GetEmail();
        bool IsValidEmail(string email);
    }
}
