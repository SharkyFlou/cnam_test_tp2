using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;
using LoanLibrary.LoanData;
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
        public void AskHabit(InterestInsuranceModifier habit);
        public void AskInterestQuality(List<InterestType> interestTypes);
        public void AskDurationInYears();
        public void AskCurrentYear();
        public void AskForCapital();
        public void DisplayResult(LoanSummary summary);
        public void DisplayMessage(string message);
    }
}
