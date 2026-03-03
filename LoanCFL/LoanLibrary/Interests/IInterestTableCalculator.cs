using LoanLibrary.Interests;

namespace LoanLibrary.Interests
{
    public interface IInterestTableCalculator
    {
        double GetInterestRate(InterestType interestType, int months);
    }
}
