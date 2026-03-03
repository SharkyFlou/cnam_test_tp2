using LoanLibrary.LoanData;

namespace LoanTest
{
    public class LoanSummaryTests
    {

        [Theory]
        [InlineData(12, 500.0, 25.0, 2000.0, 600.0, 5000.0)]
        [InlineData(0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        [InlineData(240, 463.51, 20.83, 11242.40, 5000.0, 100000.0)]
        public void Constructor_ShouldSetAllFields(
            int currentMonth, double baseMensuality, double insuranceMensuality,
            double totalInterest, double totalInsurance, double capitalPaid)
        {
            var summary = new LoanSummary(currentMonth, baseMensuality, insuranceMensuality, totalInterest, totalInsurance, capitalPaid);

            Assert.Equal(currentMonth, summary.CurrentMonth);
            Assert.Equal(baseMensuality, summary.BaseMensuality);
            Assert.Equal(insuranceMensuality, summary.InsuranceMensuality);
            Assert.Equal(totalInterest, summary.TotalInterest);
            Assert.Equal(totalInsurance, summary.TotalInsuranceInterest);
            Assert.Equal(capitalPaid, summary.CurrentCapitalPaid);
        }


        [Theory]
        [InlineData(500.0, 25.0)]
        [InlineData(0.0, 0.0)]
        [InlineData(463.51, 20.83)]
        public void TotalMensuality_ShouldEqualBasePlusInsurance(double baseMensuality, double insuranceMensuality)
        {
            var summary = new LoanSummary(12, baseMensuality, insuranceMensuality, 0, 0, 0);

            double expected = baseMensuality + insuranceMensuality;

            Assert.Equal(expected, summary.TotalMensuality, 4);
        }
    }
}
