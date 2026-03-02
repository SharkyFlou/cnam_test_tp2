using LoanLibrary.InsuranceInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDisplay
{
    public interface IInput
    {
        public InterestInsuranceModifier GetJob();
        public List<InterestInsuranceModifier> GetHabits();
    }
}
