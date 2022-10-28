using Xunit;

namespace Calculator.Tests
{
    public class AverageCalculatorTests
    {
        [Fact]
        public void Calculate_Average()
        {
            //Arrange
            var sut = new AverageCalculator();
            var input = new double[] { 5, 4, 3 };

            //Act
            var result = sut.CalculateAverage(input);

            //Assert
            Assert.Equal(4, result);
        }
    }
}
