namespace LoanLibrary
{
    public class LoanCalculator
    {
        public static double CalculateMonthlyPayment(
            double loanAmount,
            double annualInterestRate,
            int loanTermInMonths
        )
        {
            double quotient = loanAmount * (annualInterestRate / 12);
            double divisor = 1 - Math.Pow(1 + (annualInterestRate / 12), -loanTermInMonths);
            return quotient / divisor;
        }
    }
}
