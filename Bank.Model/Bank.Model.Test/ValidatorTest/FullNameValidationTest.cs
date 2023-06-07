using Bank.Model.Common.Implementations;
using Xunit;

namespace Bank.Model.Test.ValidatorTest
{
    public class FullNameValidationTests
    {
        [Theory]
        [InlineData("John Doe", true)] // Valid full name with two words
        [InlineData("John", false)] // Invalid full name with one word
        [InlineData("", false)] // Empty full name
        public void GetFullName_ValidatesFullNameCorrectly(string fullName, bool expectedResult)
        {
            // Arrange
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput

            // Act
            bool isValid = userInput.IsValidFullName(fullName);

            // Assert
            Assert.Equal(expectedResult, isValid);
        }
    }
}
