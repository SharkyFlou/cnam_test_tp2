using LoanLibrary.InsuranceInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.Interests
{
    public class InterestRate
    {
        private List<InterestInsuranceModifier> interestModifiers { get; set; }
        private float _baseModifier = 0.3f;

        public InterestRate()
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
