namespace LoanLibrary
{
    public class LoanCalculator
    {
        public static double CalculateMonthlyPayment(Loan loan)
        {
            double interestRate = loan.GetTotalInterestRate();

            double quotient = loan.Capital * (interestRate / 12);
            double divisor = 1 - Math.Pow(1 + (interestRate / 12), -loan.DurationMonths);
            return quotient / divisor;
        }
    }
}
