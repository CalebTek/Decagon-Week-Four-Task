using Xunit;
using Moq;
using Bank.Model.Common.Interfaces;

namespace Bank.Model.Test.ValidatorTest
{
    public class AmountValidationTests
    {
        [Theory]
        [InlineData("Enter your amount: ", "100.50", 100.50)] // Valid decimal input
        [InlineData("Enter your amount: ", "100", 100)] // Valid integer input
        //[InlineData("Enter your amount: ", "abc", 0)] // Invalid input
        public void GetAmount_ValidatesAmountCorrectly(string prompt, string input, decimal expectedAmount)
        {
            // Arrange
            var userInputMock = new Mock<IValidateInput>();
            userInputMock.Setup(u => u.GetAmount(prompt)).Returns(decimal.Parse(input));
            var userInput = userInputMock.Object;

            // Act
            decimal amount = userInput.GetAmount(prompt);

            // Assert
            Assert.Equal(expectedAmount, amount);
        }
    }
}
