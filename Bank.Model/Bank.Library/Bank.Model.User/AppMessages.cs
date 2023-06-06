using System.Web;

namespace Bank.Model.User
{
    public static class AppMessages
    {
        public readonly static string startMessage = $"MAIN MENU\n1. Create Account\n2. Login\n3. Exit";
        public readonly static string userMessage = $"USER MENU\n1. Deposit\n2. Withdraw\n" +
            $"3. Transfer\n4. Print Statement\n5. Display Balance\n6. Set Up Another Account\n" +
            $"7. Exit";
        public readonly static string AccountMessage = $"1. Savings\n2. Current";
        public readonly static string AppMessage = $"We are delighted to welcome you to our bank!\n" +
            $"We are committed to providing you with the best banking experience possible and\n" +
            $"We look forward to serving you.\n";
        public readonly static string ExitMessage = $"Thank you for choosing our bank.\n" +
            $"We appreciate your business and\n" +
            $"We hope to build a long-lasting relationship with you.";
    }
}
