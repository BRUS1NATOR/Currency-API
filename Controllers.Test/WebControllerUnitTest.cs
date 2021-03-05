using CurrencyAPI;
using CurrencyAPI.Models;
using CurrencyAPI.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using Xunit;

namespace CurrencyWebAPI.Test
{
    public class WebControllerUnitTest
    {
        Mock<ICurrencyService> mock;
        public WebControllerUnitTest()
        {
            mock = new Mock<ICurrencyService>();
        }

        [Fact]
        public void RequestPagedList()
        {
            //Arrange
            PagedList<DayModel> testModel = new PagedList<DayModel>() { elementsOnPage = 10, pageId = 1, totalCount = 10, value = new DayModel() };
            mock.Setup(a => a.GetCurrenciesPagination(DateTime.Parse("2021-02-27"), 1, 10)).Returns(testModel);

            CurrenciesController controller = new CurrenciesController(new NullLogger<CurrenciesController>(), mock.Object);

            // Act
            var result = controller.GetCurrencies(DateTime.Parse("2021-02-27"), 1);

            // Assert
            Assert.Equal(testModel, result);
        }

        [Fact]
        public void RequestGetCurrency()
        {
            //Arrange
            CurrencyModel testModel = new CurrencyModel() { ValuteID = "123456" };
            mock.Setup(a => a.GetCurrency(DateTime.Parse("2021-02-27"), "123456")).Returns(testModel);
            CurrenciesController controller = new CurrenciesController(new NullLogger<CurrenciesController>(), mock.Object);

            // Act
            var result = controller.GetCurrency("123456", DateTime.Parse("2021-02-27"));

            // Assert
            Assert.Equal(testModel, result);
        }
    }
}
