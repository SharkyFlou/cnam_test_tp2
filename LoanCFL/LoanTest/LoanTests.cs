using LoanLibrary.InsuranceInterest;
using LoanLibrary.LoanData;
using LoanLibrary.Rules;

namespace LoanTest
{
    public class LoanTests
    {
        private static InsuranceInterest CreateDefaultInsurance()
        {
            var modifiers = new List<InterestInsuranceModifier>
            {
                new InterestInsuranceModifier("TestJob", -0.05f, InterestInsuranceType.Job)
            };
            return new InsuranceInterest(modifiers);
        }


        [Theory]
        [InlineData(50000, 120, 0.67)]
        [InlineData(100000, 240, 1.04)]
        [InlineData(200000, 300, 1.27)]
        public void Constructor_ValidCapital_ShouldCreateLoan(double capital, int durationMonths, double interestRate)
        {
            var insurance = CreateDefaultInsurance();

            var loan = new Loan(capital, durationMonths, insurance, interestRate);

            Assert.Equal(capital, loan.Capital);
            Assert.Equal(durationMonths, loan.DurationMonths);
            Assert.Equal(interestRate, loan.Interest);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(10000)]
        [InlineData(49999)]
        [InlineData(-1)]
        public void Constructor_CapitalBelowMinimum_ShouldThrowArgumentException(double capital)
        {
            var insurance = CreateDefaultInsurance();

            Assert.Throws<ArgumentException>(() => new Loan(capital, 120, insurance, 0.67));
        }

        [Fact]
        public void Constructor_ExactMinimumCapital_ShouldSucceed()
        {
            var insurance = CreateDefaultInsurance();

            var loan = new Loan(LoanRules.CAPITAL_MIN, 120, insurance, 0.67);

            Assert.Equal(LoanRules.CAPITAL_MIN, loan.Capital);
        }


        [Theory]
        [InlineData(0.67, -0.05f, 0.3f)]
        [InlineData(1.04, 0.15f, 0.3f)]
        public void GetTotalInterestRate_ShouldReturnInterestPlusInsuranceSum(double interestRate, float modifierRate, float baseRate)
        {
            var modifiers = new List<InterestInsuranceModifier>
            {
                new InterestInsuranceModifier("Test", modifierRate, InterestInsuranceType.Job)
            };
            var insurance = new InsuranceInterest(modifiers);
            var loan = new Loan(100000, 120, insurance, interestRate);

            double expected = interestRate + (baseRate + modifierRate);
            double result = loan.GetTotalInterestRate();

            Assert.Equal(expected, result, 4);
        }


        [Theory]
        [InlineData(-0.05f)]
        [InlineData(0.15f)]
        [InlineData(0.0f)]
        public void GetTotalInsuranceInterestRate_ShouldReturnInsuranceSum(float modifierRate)
        {
            var modifiers = new List<InterestInsuranceModifier>
            {
                new InterestInsuranceModifier("Test", modifierRate, InterestInsuranceType.Habits)
            };
            var insurance = new InsuranceInterest(modifiers);
            var loan = new Loan(100000, 120, insurance, 0.67);

            float expected = 0.3f + modifierRate;
            double result = loan.GetTotalInsuranceInterestRate();

            Assert.Equal(expected, result, 4);
        }
    }
}
