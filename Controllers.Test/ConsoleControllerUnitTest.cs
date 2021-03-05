using CurrencyAPI;
using CurrencyAPI.Models;
using CurrencyAPI.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;

namespace ConsoleController.Test
{
    public class ConsoleControllerUnitTest
    {
        public const string pathToResource = "CBR_values.txt";

        private readonly UnitOfWork UnitOfWork;

        public ConsoleControllerUnitTest()
        {
            UnitOfWork = new UnitOfWork(new CurrenciesDbContext());
        }

        [Fact]
        public void ControllerParseURI()
        {
            //Arrange
            Mock<ICustomParser<DayModel>> parser = new Mock<ICustomParser<DayModel>>();
            Mock<ICurrencyService> service = new Mock<ICurrencyService>();

            DayModel expected = new DayModel() { Date = DateTime.Parse("2021-04-03") };
            parser.Setup(x => x.TryParseURI("http://www.cbr.ru/123456789")).Returns(expected);

            ParseController parseController = new ParseController(parser.Object, service.Object);

            //Act
            DayModel result = parseController.ParseURI("http://www.cbr.ru/123456789");

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void CompareCBRParserValues(DayModel expected)
        {
            using (var db = new CurrenciesDbContext())
            {
                //Arrange
                ParseController controller = new ParseController(new CBRParser(), new CurrencyService(new UnitOfWork(db)));

                //Act
                DayModel result = controller.ParseString(File.ReadAllText(pathToResource));

                //Assert
                Assert.Equal(expected.Date.Date, result.Date.Date);
                Assert.Equal(expected.Currencies.Count, result.Currencies.Count);
            }
        }

        public static IEnumerable<object[]> TestData()
        {
            return new List<object[]>
            {
                new object[]{
                    new DayModel
                    {
                        Date = DateTime.Parse("2021-02-27"),
                        Currencies = new List<CurrencyModel>(new CurrencyModel[34])
                    }
                }
            };
        }
    }
}
