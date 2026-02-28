using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.Interests
{
    public class InterestRate
    {
        private List<InterestModifier> interestModifiers { get; set; }
        private float baseModifier = 0.3f;

        public InterestRate()
        {
            interestModifiers = new List<InterestModifier>();
        }

        public void AddModifier(InterestModifier modifier)
        {
            interestModifiers.Add(modifier);
        }

        public float GetInterestSum()
        {
            float finalRate = baseModifier;
            foreach (InterestModifier modifier in interestModifiers)
            {
                finalRate += modifier._rate;
            }
            return finalRate;
        }
    }
}
