using CryptoCurrency;

namespace TestCryptoCurrecy
{
    public class UnitTest1
    {
        [Fact]
        public void SimpleBlackBoxText()
        {
            Converter converter = new Converter();
            converter.SetPricePerUnit("Bitcoin", 20000);
            converter.SetPricePerUnit("Ethereum", 1300);

            var result = converter.Convert("Bitcoin", "Ethereum", 2);

            // Expected = 20000 * 2 / 1300 = 30.76923076923077
            Assert.Equal(30.76923076923077, result);
        }

        [Fact]
        public void SimpleBlackBoxText2()
        {
            Converter converter = new Converter();
            converter.SetPricePerUnit("STEPN", 0.6433198);
            converter.SetPricePerUnit("HBAR", 0.060488);

            var result = converter.Convert("STEPN", "HBAR", 1265487);

            // Expected = 0.6433198 * 1265487 / 0.060488 = 13459080.210001983
            Assert.Equal(13459080.210001983, result);
        }

        [Fact]
        public void ZeroAmount()
        {
            Converter converter = new Converter();
            converter.SetPricePerUnit("STEPN", 0.6433198);
            converter.SetPricePerUnit("HBAR", 0.060488);

            var result = converter.Convert("STEPN", "HBAR", 0);

            // Expected = 0.6433198 * 0 / 0.060488 = 0
            Assert.Equal(0, result);
        }

        [Fact]
        public void ZeroPrice()
        {
            Converter converter = new Converter();
            converter.SetPricePerUnit("STEPN", 0.6433198);
            converter.SetPricePerUnit("LUNA", 0);

            var result = converter.Convert("STEPN", "LUNA", 100);

            // Expected = 0.6433198 * 100 / 0 = {Infinity}
            Assert.Equal(double.MaxValue, result);
        }

        [Fact]
        public void UnknownCurrency()
        {
            Converter converter = new Converter();
            converter.SetPricePerUnit("STEPN", 0.6433198);
            converter.SetPricePerUnit("Ethereum", 1300);

            // Bitcoin is not defined
            Assert.Throws<ArgumentException>(() => converter.Convert("Ethereum", "Bitcoin", 10));
        }

        [Fact]
        public void NegativePrice()
        {
            Converter converter = new Converter();

            converter.SetPricePerUnit("Ethereum", 1300);
            Assert.Throws<ArgumentException>(() => converter.SetPricePerUnit("STEPN", -1));

        }

        [Fact]
        public void NegativeAmount()
        {
            Converter converter = new Converter();

            converter.SetPricePerUnit("Bitcoin", 20000);
            converter.SetPricePerUnit("Ethereum", 1300);

            Assert.Throws<ArgumentException>(() => converter.Convert("Ethereum", "Bitcoin", -1));

        }
    }
}