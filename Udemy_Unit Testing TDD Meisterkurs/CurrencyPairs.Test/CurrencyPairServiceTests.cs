using CurrencyPairs.Aplication;
using CurrencyPairs.Contracts;
using CurrencyPairs.Exeptions;
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

            Mock<ICurrencyPairRepositorie> currencyPairRepositoryMock = new Mock<ICurrencyPairRepositorie>();
            currencyPairRepositoryMock.Setup(cpr => cpr.GetCurrencyPair(currencyPair.CurrencyCode1, currencyPair.CurrencyCode2))
                                       .Returns(currencyPair);
            Mock<ILogerWrapper> loggerWrapperMock = new Mock<ILogerWrapper>();

            var sut = new CurrencyPairService(currencyPairRepositoryMock.Object, loggerWrapperMock.Object);

            //Act
            var result = sut.GetRate(currencyPair.CurrencyCode1, currencyPair.CurrencyCode2);

            //Assert
            Assert.Equal(1.12, result);
            loggerWrapperMock.Verify(lw => lw.LogCurrencyPairRequested(currencyPair.CurrencyCode2, currencyPair.CurrencyCode2), Times.Once();
        }

        [Fact]
        public void Throws_CurrencyPairNotFoundException_If_CurrencyPair_Does_Not_Exist()
        {
            //Arrange

            Mock<ICurrencyPairRepositorie> currencyPairRepositoryMock = new Mock<ICurrencyPairRepositorie>();
            currencyPairRepositoryMock.Setup(cpr => cpr.GetCurrencyPair(It.IsAny<string>(), It.IsAny<string>()))
                                       .Returns<CurrencyPair?>(null);

            var sut = new CurrencyPairService(currencyPairRepositoryMock.Object);

            //Act
            Action act = () => sut.GetRate("EUR", "USD");

            //Assert
            Assert.Throws<CurrencyPairNotFoundException>(act);
        }
    }
}