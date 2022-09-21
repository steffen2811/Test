using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TransportPrice;

namespace TestTransportPrice
{
    public class TransportPriceTestInlineData
    {
        [Theory]
        [InlineData(9.99, 4.95, 0)]
        [InlineData(10, 4.9999, 50)]
        [InlineData(9.99, 5, 75)]
        [InlineData(10, 5, 100)]
        public void TestTransportPrice(double weight, double distance, double expectedResult)
        {
            var transportPrice = new TransportPriceClass();
            double result = transportPrice.GetPrice(weight, distance);

            Assert.Equal(expectedResult, result);
        }
    }
}
