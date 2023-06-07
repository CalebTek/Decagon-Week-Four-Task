using Bank.Model.Common.Implementations;
using Xunit;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetEmailValidationTest
    {
        [Theory]
        [InlineData("test@example.com", false)] // Valid email address
        [InlineData("test", false)] // Invalid email address
        [InlineData("test@example", false)] // Invalid email address
        [InlineData("test@.com", false)] // Invalid email address
                                         //public void GetEmail_ValidatesEmailCorrectly(string input, bool expectedIsValid)
                                         //{
                                         //    // Arrange
                                         //    var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

        //    // Act
        //    string email = userInput.GetEmail();

        //    // Assert
        //    if (expectedIsValid)
        //    {
        //        Assert.Equal(input, email);
        //    }
        //    else
        //    {
        //        Assert.NotEqual(input, email);
        //    }
        //}

        public void IsValidEmail_ValidatesEmailCorrectly(string input, bool expectedIsValid)
        {
            // Arrange
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

            // Act
            bool isValid = userInput.IsValidEmail(input);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }
    }
}
