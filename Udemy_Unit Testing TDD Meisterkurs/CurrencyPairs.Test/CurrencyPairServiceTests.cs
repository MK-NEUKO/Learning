using CurrencyPairs.Aplication;
using CurrencyPairs.Contracts;
using CurrencyPairs.Model;
using Moq;

namespace CurrencyPairs.Test
{
    public class CurrencyPairServiceTests
    {
        [Fact]
        public void Returns_Rate_For_Existing_CurrencyPair()
        {
            //Arrange
            var currencyPair = new CurrencyPair()
            {
                CurrencyCode1 = "EUR",
                CurrencyCode2 = "USD",
                Id = 1,
                Rate = 1.12
            };

            Mock<ICurrencyPairRepositorie> currencyPairRepositorieMock = new Mock<ICurrencyPairRepositorie>();
            currencyPairRepositorieMock.Setup(cpr => cpr.GetCurrencyPair(currencyPair.CurrencyCode1, currencyPair.CurrencyCode2))
                                       .Returns(currencyPair);

            var sut = new CurrencyPairService(currencyPairRepositorieMock.Object);

            //Act
            var result = sut.GetRate(currencyPair.CurrencyCode1, currencyPair.CurrencyCode2);

            //Assert
            Assert.Equal(1.12, result);
        }
    }
}