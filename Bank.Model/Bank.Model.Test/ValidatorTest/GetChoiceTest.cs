using Xunit;
using System;
using System.IO;
using Bank.Model.Common.Implementations;

namespace Bank.Model.Test.ValidatorTest
{
    public class GetChoiceTest
    {
        [Fact]
        public void GetChoice_ValidInput_ReturnsChoice()
        {
            // Arrange
            int expectedChoice = 3;
            string input = "3" + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
            int actualChoice = userInput.GetChoice(5);

            // Assert
            Assert.Equal(expectedChoice, actualChoice);
        }

        [Fact]
        public void GetChoice_InvalidInputThenValidInput_ReturnsValidChoice()
        {
            // Arrange
            int expectedChoice = 2;
            string input = "abc" + Environment.NewLine + "2" + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
            int actualChoice = userInput.GetChoice(5);

            // Assert
            Assert.Equal(expectedChoice, actualChoice);
        }

        [Fact]
        public void GetChoice_InputOutOfRangeThenValidInput_ReturnsValidChoice()
        {
            // Arrange
            int expectedChoice = 4;
            string input = "6" + Environment.NewLine + "4" + Environment.NewLine;
            var reader = new StringReader(input);
            Console.SetIn(reader);

            // Act
            var userInput = new ConsoleUserInput(); // Assuming ConsoleUserInput implements IValidateInput
            int actualChoice = userInput.GetChoice(5);

            // Assert
            Assert.Equal(expectedChoice, actualChoice);
        }
    }
}
