using LoanLibrary.LoanData;

namespace LoanLibrary
{
    public interface ILoanCalculator
    {
        double CalculateTotalInterest(Loan loan);
        LoanSummary CalculateLoanSummary(Loan loan, int monthsElapsed);
    }
}
