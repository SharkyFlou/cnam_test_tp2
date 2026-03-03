using LoanLibrary.InsuranceInterest;

namespace LoanTest
{
    public class InsuranceInterestTests
    {
        private const float BaseModifier = 0.3f;


        [Fact]
        public void GetInterestSum_NoModifiers_ShouldReturnBaseModifier()
        {
            var insurance = new InsuranceInterest(new List<InterestInsuranceModifier>());

            float result = insurance.GetInterestSum();

            Assert.Equal(BaseModifier, result, 4);
        }


        [Theory]
        [InlineData(0.1f)]
        [InlineData(-0.05f)]
        [InlineData(0.0f)]
        [InlineData(0.3f)]
        public void GetInterestSum_SingleModifier_ShouldReturnBasePlusRate(float rate)
        {
            var modifiers = new List<InterestInsuranceModifier>
            {
                new InterestInsuranceModifier("Test", rate, InterestInsuranceType.Job)
            };
            var insurance = new InsuranceInterest(modifiers);

            float expected = BaseModifier + rate;
            float result = insurance.GetInterestSum();

            Assert.Equal(expected, result, 4);
        }


        [Fact]
        public void GetInterestSum_MultipleModifiers_ShouldSumAllRates()
        {
            var modifiers = new List<InterestInsuranceModifier>
            {
                new InterestInsuranceModifier("Sportif", -0.05f, InterestInsuranceType.Habits),
                new InterestInsuranceModifier("Fumeur", 0.15f, InterestInsuranceType.Habits),
                new InterestInsuranceModifier("Pilote", 0.15f, InterestInsuranceType.Job)
            };
            var insurance = new InsuranceInterest(modifiers);

            float expected = BaseModifier + (-0.05f) + 0.15f + 0.15f;
            float result = insurance.GetInterestSum();

            Assert.Equal(expected, result, 4);
        }
    }
}
