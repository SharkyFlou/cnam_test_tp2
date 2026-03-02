using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;

namespace LoanLibrary
{
    public class Loan
    {
        public readonly double Capital;
        public readonly int DurationMonths;
        private InterestRate _interestRate;

        public Loan(double capital, int durationMonths, InterestRate interestRate)
        {
            if (capital < 50000)
                throw new ArgumentException("Capital minimum 50k");

            Capital = capital;
            DurationMonths = durationMonths;
            _interestRate = interestRate;
        }

        public double GetTotalInterestRate()
        {
            return _interestRate.GetInterestSum();
        }

        public void AddInsuranceInterestModifier(InterestInsuranceModifier modifier)
        {
            _interestRate.AddModifier(modifier);
        }
    }
}
