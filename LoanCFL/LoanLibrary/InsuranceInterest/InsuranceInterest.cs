using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.InsuranceInterest
{
    public class InsuranceInterest
    {
        private List<InterestInsuranceModifier> interestModifiers { get; set; }
        private static readonly float _baseModifier = 0.3f;

        public InsuranceInterest()
        {
            interestModifiers = new List<InterestInsuranceModifier>();
        }

        public void AddModifier(InterestInsuranceModifier modifier)
        {
            interestModifiers.Add(modifier);
        }

        public float GetInterestSum()
        {
            float finalRate = _baseModifier;
            foreach (InterestInsuranceModifier modifier in interestModifiers)
            {
                finalRate += modifier._rate;
            }
            return finalRate;
        }
    }
}
