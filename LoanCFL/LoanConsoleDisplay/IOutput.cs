using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDisplay
{
    public interface IOutput
    {
        public void AskForJob(List<InterestInsuranceModifier> availableJobs);
        public void AskHabits(List<InterestInsuranceModifier> availableHabits);
        public void AskInterestQuality(List<InterestType> interestTypes);
        public void AskDurationInYears();

        public void AskCurrentYear();
    }
}
