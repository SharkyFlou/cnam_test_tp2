using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;
using LoanLibrary.LoanData;

namespace LoanConsoleDisplay
{
    public interface IGUI
    {
        int GetCapital();
        InterestInsuranceModifier GetJob(List<InterestInsuranceModifier> availableJobs);
        List<InterestInsuranceModifier> GetHabits(List<InterestInsuranceModifier> availableHabits);
        InterestType GetInterestQuality(List<InterestType> interestTypes);
        int GetDurationInYears();
        int GetCurrentYear();
        void DisplayMessage(string message);
    }
}
