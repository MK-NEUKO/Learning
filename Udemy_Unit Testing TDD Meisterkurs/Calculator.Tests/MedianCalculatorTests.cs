namespace Calculator.Tests
{
    public class MedianCalculatorTests
    {
        [Fact]
        public void Calculate_Median()
        {
            //Arrange
            var sut = new MedianCalculator();
            var input = new double[] { 1.0, 4.0, 10.0 };

            //Act
            var result = sut.CalculateMedian(input);

            //Assert
            Assert.Equal(4.0, result);
        }
    }
}