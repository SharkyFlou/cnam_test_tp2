using LoanLibrary.LoanData;

namespace LoanLibrary
{
    public class LoanCalculator
    {
        private static double CalculateLoanMensuality(double interestRate, double capital, int durationMonths)
        {
            interestRate /= 100; // Convert percentage to decimal
            double interestRatePerMonth = interestRate /12; // Convert to percentage for display

            double quotient = capital * interestRatePerMonth;
            double divisor = 1 - Math.Pow(1 + interestRatePerMonth, -durationMonths);
            return quotient / divisor;
        }

        public static double CalculateTotalInterest(Loan loan)
        {
            double mensuality = CalculateLoanMensuality(loan.Interest, loan.Capital, loan.DurationMonths);
            return mensuality * loan.DurationMonths - loan.Capital;
        }


        public static LoanSummary CalculateLoanSummary(Loan loan, int monthsElapsed)
        {
            if (monthsElapsed < 0 || monthsElapsed > loan.DurationMonths)
                throw new ArgumentException("Invalid number of months elapsed.");
             
            double baseMensuality = CalculateLoanMensuality(loan.Interest, loan.Capital, loan.DurationMonths);
            double insuranceMensuality = loan.Capital * (loan.GetTotalInsuranceInterestRate() / 100 / 12);
            double currentCapitalPaid = CalculateCapitalPaid(loan, monthsElapsed);

            double totalInterest = CalculateTotalInterest(loan);
            double totalInsurance = insuranceMensuality * loan.DurationMonths;

            return new LoanSummary
            (
                monthsElapsed,
                baseMensuality,
                insuranceMensuality,
                totalInterest,
                totalInsurance,
                currentCapitalPaid
            );
        }

        private static double CalculateCapitalPaid(Loan loan, int monthsElapsed)
        {
            double monthlyInterestRate = loan.Interest / 12 / 100; // Assuming InterestRate is annual
            double monthlyPayment = CalculateLoanMensuality(loan.Interest, loan.Capital, loan.DurationMonths);

            double currentCapitalPaid = 0;
            double remainingCapital = loan.Capital;

            for (int i = 0; i < monthsElapsed; i++)
            {
                double interestForMonth = remainingCapital * monthlyInterestRate;
                double principalForMonth = monthlyPayment - interestForMonth;
                currentCapitalPaid += principalForMonth;
                remainingCapital -= principalForMonth;
            }

            return currentCapitalPaid;
        }
    }
}
