using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using DXC_Fibonacci.Services;
using System.Linq;

namespace DXC_Fibonacci_Tests
{
    [TestClass]
    public class DXCFibonacciTests : DXCTestBase
    {
        /// <summary>
        /// Fibonacci series numbers count should be matched
        /// </summary>
        [TestMethod]
        public void SeriesCountShouldBeMatched()
        {
            Length = 8;
            FibonacciService.GetNthFibonacciSeries(Length)
                            .Count()
                            .Should()
                            .BeGreaterThan(0).And.Be(Length);
        }

        /// <summary>
        /// Verify each number in the series
        /// </summary>
        [TestMethod]
        public void VerifyEachNumberInTheSeries()
        {
            Length = 8;
            var series = FibonacciService.GetNthFibonacciSeries(Length).ToList();

            for (int i = 0; i < (series.Count - 2); i++)
            {
                (series[i] + series[i + 1]).Should().Be(series[i + 2]);
            }
        }

        /// <summary>
        /// Verify each number in the mocked series
        /// </summary>
        [TestMethod]
        public void MockedSeriesCountShouldBeMatched()
        {
            Length = 8;
            MFibonacciService.Object.GetNthFibonacciSeries(Length)
                                    .Count()
                                    .Should()
                                    .BeGreaterThan(0).And.Be(Length);
        }

        [TestMethod]
        public void VerifyEachNumberInTheMockedSeries()
        {
            Length = 8;
            var series = MFibonacciService.Object.GetNthFibonacciSeries(Length).ToList();

            for (int i = 0; i < (series.Count - 2); i++)
            {
                (series[i] + series[i + 1]).Should().Be(series[i + 2]);
            }
        }
    }


    public class DXCTestBase
    {
        protected Mock<IFibonacciService> MFibonacciService = new Mock<IFibonacciService>();
        protected IFibonacciService FibonacciService = null;
        protected int Length = 8;

        public DXCTestBase()
        {
            FibonacciService = new FibonacciService();
            MFibonacciService.Setup(x => x.GetNthFibonacciSeries(Length))
                             .Returns(FibonacciService.GetNthFibonacciSeries(Length));
        }
    }
}
