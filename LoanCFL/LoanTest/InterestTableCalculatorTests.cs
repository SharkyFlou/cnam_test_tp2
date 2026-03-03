using LoanLibrary.Interests;

namespace LoanTest
{
    public class InterestTableCalculatorTests
    {
        private readonly IInterestTableCalculator _calculator = new InterestTableCalculator();


        [Theory]
        [InlineData(108, 0.62)]  // 9 years → rounds to 7
        [InlineData(120, 0.67)]  // 10 years → rounds to 10
        [InlineData(180, 0.85)]  // 15 years → rounds to 15
        [InlineData(240, 1.04)]  // 20 years → rounds to 20
        [InlineData(300, 1.27)]  // 25 years → rounds to 25
        public void GetInterestRate_GoodRate_ShouldReturnExpectedRate(int months, double expectedRate)
        {
            double result = _calculator.GetInterestRate(InterestType.GoodRate, months);

            Assert.Equal(expectedRate, result);
        }


        [Theory]
        [InlineData(108, 0.43)]  // 9 years → rounds to 7
        [InlineData(120, 0.55)]  // 10 years → rounds to 10
        [InlineData(180, 0.73)]  // 15 years → rounds to 15
        [InlineData(240, 0.91)]  // 20 years → rounds to 20
        [InlineData(300, 1.15)]  // 25 years → rounds to 25
        public void GetInterestRate_VeryGoodRate_ShouldReturnExpectedRate(int months, double expectedRate)
        {
            double result = _calculator.GetInterestRate(InterestType.VeryGoodRate, months);

            Assert.Equal(expectedRate, result);
        }


        [Theory]
        [InlineData(108, 0.35)]  // 9 years → rounds to 7
        [InlineData(120, 0.45)]  // 10 years → rounds to 10
        [InlineData(180, 0.58)]  // 15 years → rounds to 15
        [InlineData(240, 0.73)]  // 20 years → rounds to 20
        [InlineData(300, 0.89)]  // 25 years → rounds to 25
        public void GetInterestRate_ExcellentRate_ShouldReturnExpectedRate(int months, double expectedRate)
        {
            double result = _calculator.GetInterestRate(InterestType.ExcellentRate, months);

            Assert.Equal(expectedRate, result);
        }

        [Theory]
        [InlineData(132, 0.85)]  // 11 years → rounds to 15 for GoodRate
        [InlineData(156, 0.85)]  // 13 years → rounds to 15 for GoodRate
        [InlineData(204, 1.04)]  // 17 years → rounds to 20 for GoodRate
        public void GetInterestRate_IntermediateDuration_GoodRate_ShouldRoundCorrectly(int months, double expectedRate)
        {
            double result = _calculator.GetInterestRate(InterestType.GoodRate, months);

            Assert.Equal(expectedRate, result);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(96)]   // 8 years < 9
        public void GetInterestRate_DurationTooShort_ShouldThrowArgumentException(int months)
        {
            Assert.Throws<ArgumentException>(() => _calculator.GetInterestRate(InterestType.GoodRate, months));
        }


        [Theory]
        [InlineData(312)]  // 26 years
        [InlineData(360)]  // 30 years
        [InlineData(600)]  // 50 years
        public void GetInterestRate_DurationTooLong_ShouldThrowArgumentException(int months)
        {
            Assert.Throws<ArgumentException>(() => _calculator.GetInterestRate(InterestType.GoodRate, months));
        }
    }
}
