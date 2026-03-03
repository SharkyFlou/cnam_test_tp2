using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.InsuranceInterest
{
    public class InsuranceInterest
    {
        private readonly List<InterestInsuranceModifier> _interestModifiers;
        private static readonly float _baseModifier = 0.3f;

        public InsuranceInterest(List<InterestInsuranceModifier> interestModifiers)
        {
            _interestModifiers = interestModifiers;
        }

        public float GetInterestSum()
        {
            float finalRate = _baseModifier;
            foreach (InterestInsuranceModifier modifier in _interestModifiers)
            {
                finalRate += modifier._rate;
            }
            return finalRate;
        }
    }
}
