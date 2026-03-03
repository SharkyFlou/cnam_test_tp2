using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;

namespace LoanLibrary.LoanData
{
    public class Loan
    {
        public readonly double Capital;
        public readonly int DurationMonths;
        private InsuranceInterest.InsuranceInterest _insuranceInterestRate;
        public readonly double Interest;

        public Loan(double capital, int durationMonths, InsuranceInterest.InsuranceInterest insuranceInterestRate, InterestType interestType)
        {
            if (capital < 50000)
                throw new ArgumentException("Capital minimum 50k");

            Capital = capital;
            DurationMonths = durationMonths;
            _insuranceInterestRate = insuranceInterestRate;
            Interest = InterestTableCalculator.GetInterestRate(interestType, durationMonths);
        }

        public double GetTotalInterestRate()
        {
            return Interest + _insuranceInterestRate.GetInterestSum();
        }

        public double GetTotalInsuranceInterestRate()
        {
            return _insuranceInterestRate.GetInterestSum();
        }
    }
}
