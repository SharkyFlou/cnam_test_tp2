using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.LoanData
{
    public class LoanSummary
    {
        public readonly int CurrentMonth;

        public readonly double Mensuality;
        public readonly double InterestMensuality;
        public readonly double InsuranceMensuality;

        public readonly double TotalInterest;
        public readonly double TotalInsuranceInterest;

        public readonly double CurrentCapitalPaid;
        public readonly double CurrentInterestPaid;
        public readonly double CurrentInsurancePaid;

        public LoanSummary(int currentMonth, double mensuality, double interestMensuality, double insuranceMensuality, double totalInterest, double totalInsuranceInterest, double currentCapitalPaid, double currentInterestPaid, double currentInsurancePaid)
        {
            CurrentMonth = currentMonth;
            Mensuality = mensuality;
            InterestMensuality = interestMensuality;
            InsuranceMensuality = insuranceMensuality;
            TotalInterest = totalInterest;
            TotalInsuranceInterest = totalInsuranceInterest;
            CurrentCapitalPaid = currentCapitalPaid;
            CurrentInterestPaid = currentInterestPaid;
            CurrentInsurancePaid = currentInsurancePaid;
        }
    }
}
