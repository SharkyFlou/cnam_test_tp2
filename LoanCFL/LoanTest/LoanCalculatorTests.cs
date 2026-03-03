using LoanLibrary;
using LoanLibrary.InsuranceInterest;
using LoanLibrary.LoanData;

namespace LoanTest
{
    public class LoanCalculatorTests
    {
        private readonly ILoanCalculator _calculator = new LoanCalculator();

        private static Loan CreateStandardLoan(double capital = 100000, int durationMonths = 240, double interestRate = 1.04)
        {
            var modifiers = new List<InterestInsuranceModifier>
            {
                new InterestInsuranceModifier("TestJob", -0.05f, InterestInsuranceType.Job)
            };
            var insurance = new InsuranceInterest(modifiers);
            return new Loan(capital, durationMonths, insurance, interestRate);
        }


        [Theory]
        [InlineData(100000, 120, 0.67)]
        [InlineData(100000, 240, 1.04)]
        [InlineData(200000, 300, 1.27)]
        public void CalculateTotalInterest_ValidLoan_ShouldReturnPositiveValue(double capital, int durationMonths, double interestRate)
        {
            var loan = CreateStandardLoan(capital, durationMonths, interestRate);

            double totalInterest = _calculator.CalculateTotalInterest(loan);

            Assert.True(totalInterest > 0, "Total interest should be positive for a loan with positive interest rate.");
        }

        [Fact]
        public void CalculateTotalInterest_ShouldBeLessThanCapital()
        {
            var loan = CreateStandardLoan(100000, 120, 0.67);

            double totalInterest = _calculator.CalculateTotalInterest(loan);

            Assert.True(totalInterest < loan.Capital, "Total interest for a low rate short loan should be less than capital.");
        }


        [Theory]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(120)]
        [InlineData(240)]
        public void CalculateLoanSummary_ValidMonths_ShouldReturnSummary(int monthsElapsed)
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            var summary = _calculator.CalculateLoanSummary(loan, monthsElapsed);

            Assert.NotNull(summary);
            Assert.Equal(monthsElapsed, summary.CurrentMonth);
        }

        [Fact]
        public void CalculateLoanSummary_ShouldHavePositiveMensuality()
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            var summary = _calculator.CalculateLoanSummary(loan, 12);

            Assert.True(summary.BaseMensuality > 0, "Base mensuality should be positive.");
            Assert.True(summary.InsuranceMensuality >= 0, "Insurance mensuality should be non-negative.");
        }

        [Fact]
        public void CalculateLoanSummary_TotalMensuality_ShouldEqualBasePlusInsurance()
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            var summary = _calculator.CalculateLoanSummary(loan, 12);

            Assert.Equal(summary.BaseMensuality + summary.InsuranceMensuality, summary.TotalMensuality, 4);
        }

        [Fact]
        public void CalculateLoanSummary_AtZeroMonths_ShouldHaveZeroCapitalPaid()
        {
            var loan = CreateStandardLoan();

            var summary = _calculator.CalculateLoanSummary(loan, 0);

            Assert.Equal(0, summary.CurrentCapitalPaid, 4);
        }

        [Fact]
        public void CalculateLoanSummary_AtFullDuration_CapitalPaidShouldApproximateCapital()
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            var summary = _calculator.CalculateLoanSummary(loan, 240);

            Assert.Equal(loan.Capital, summary.CurrentCapitalPaid, 0);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(-12)]
        [InlineData(-100)]
        public void CalculateLoanSummary_NegativeMonths_ShouldThrowArgumentException(int monthsElapsed)
        {
            var loan = CreateStandardLoan();

            Assert.Throws<ArgumentException>(() => _calculator.CalculateLoanSummary(loan, monthsElapsed));
        }

        [Theory]
        [InlineData(241)]
        [InlineData(300)]
        [InlineData(1000)]
        public void CalculateLoanSummary_MonthsBeyondDuration_ShouldThrowArgumentException(int monthsElapsed)
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            Assert.Throws<ArgumentException>(() => _calculator.CalculateLoanSummary(loan, monthsElapsed));
        }


        [Fact]
        public void CalculateLoanSummary_ShouldHavePositiveTotalInterest()
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            var summary = _calculator.CalculateLoanSummary(loan, 120);

            Assert.True(summary.TotalInterest > 0, "Total interest should be positive.");
        }

        [Fact]
        public void CalculateLoanSummary_ShouldHavePositiveTotalInsurance()
        {
            var loan = CreateStandardLoan(100000, 240, 1.04);

            var summary = _calculator.CalculateLoanSummary(loan, 120);

            Assert.True(summary.TotalInsuranceInterest >= 0, "Total insurance should be non-negative.");
        }

        [Fact]
        public void CalculateLoanSummary_Cas1()
        {
            Loan loan = new Loan(
                175000,
                25 * 12,
                new InsuranceInterest(
                    [new InterestInsuranceModifier("Fumeur", 0.15f, InterestInsuranceType.Habits),
                    new InterestInsuranceModifier("Ingénieur informatique", -0.05f, InterestInsuranceType.Job),
                    new InterestInsuranceModifier("Atteint de trouble cardiaque", 0.3f, InterestInsuranceType.Habits)
                ]),
                1.27);

            var summary = _calculator.CalculateLoanSummary(loan, 12 * 10);

            Assert.True((int)Math.Round(summary.TotalMensuality) == 783);
            Assert.True((int)Math.Round(summary.BaseMensuality) == 681);
            Assert.True((int)Math.Round(summary.InsuranceMensuality) == 102);

            Assert.True((int)Math.Round(summary.TotalInsuranceInterest) == 30625);
            Assert.True((int)Math.Round(summary.CurrentCapitalPaid) == 63420);
            Assert.True((int)Math.Round(summary.TotalInterest) == 29341);
        }

        [Fact]
        public void CalculateLoanSummary_Cas2()
        {
            Loan loan = new Loan(
                200000,
                15 * 12,
                new InsuranceInterest(
                    [new InterestInsuranceModifier("Sportif", -0.05f, InterestInsuranceType.Habits),
                    new InterestInsuranceModifier("Pilote de chasse", 0.15f, InterestInsuranceType.Job),
                ]),
                0.73);

            var summary = _calculator.CalculateLoanSummary(loan, 12 * 10);

            Assert.True((int)Math.Round(summary.TotalMensuality) == 1240);
            Assert.True((int)Math.Round(summary.BaseMensuality) == 1173);
            Assert.True((int)Math.Round(summary.InsuranceMensuality) == 67);

            Assert.True((int)Math.Round(summary.TotalInsuranceInterest) == 12000);
            Assert.True((int)Math.Round(summary.CurrentCapitalPaid) == 130886);
            Assert.True((int)Math.Round(summary.TotalInterest) == 11211);
        }
    }
}
