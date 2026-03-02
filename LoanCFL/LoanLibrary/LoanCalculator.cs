using LoanLibrary.LoanData;

namespace LoanLibrary
{
    public class LoanCalculator
    {
        private static double CalculateLoanMensuality(double interestRate, double capital, int durationMonths)
        {
            double quotient = capital * (interestRate / 12);
            double divisor = 1 - Math.Pow(1 + (interestRate / 12), -durationMonths);
            return quotient / divisor;
        } 


        public static LoanSummary CalculateLoanSummary(Loan loan, int monthsElapsed)
        {
            if (monthsElapsed < 0 || monthsElapsed > loan.DurationMonths)
                throw new ArgumentException("Invalid number of months elapsed.");

            double totalMensuality = CalculateLoanMensuality(loan.Interest + loan.GetTotalInsuranceInterestRate(), loan.Capital, loan.DurationMonths);
            double baseAndInterest = CalculateLoanMensuality(loan.Interest, loan.Capital, loan.DurationMonths);
            double baseAndInsurance = CalculateLoanMensuality(loan.GetTotalInsuranceInterestRate(), loan.Capital, loan.DurationMonths);
            double insuranceMensuality = totalMensuality - baseAndInterest;
            double interestMensuality = totalMensuality - baseAndInsurance;

            double currentInterestPaid = interestMensuality * monthsElapsed;
            double currentInsurancePaid = insuranceMensuality * monthsElapsed;
            double currentCapitalPaid = totalMensuality * (monthsElapsed / (double)loan.DurationMonths);

            double totalInterest = interestMensuality * loan.DurationMonths;
            double totalInsurance = insuranceMensuality * loan.DurationMonths;

            return new LoanSummary
            (
                monthsElapsed,
                totalMensuality,
                interestMensuality,
                insuranceMensuality,
                totalInterest,
                totalInsurance,
                currentCapitalPaid,
                currentInterestPaid,
                currentInsurancePaid
            );  
        }
    }
}
