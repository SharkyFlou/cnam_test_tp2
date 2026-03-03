using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDisplay
{
    public interface IInput
    {
        public InterestInsuranceModifier GetJob(List<InterestInsuranceModifier> availableJobs);
        public bool HasHabit();
        public InterestType GetInterestQuality(List<InterestType> interestTypes);
        public int GetDurationInYears();
        public int GetCurrentYear();
    }
}
