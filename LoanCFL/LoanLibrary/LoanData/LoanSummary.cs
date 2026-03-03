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

        public readonly double BaseMensuality;
        public readonly double InsuranceMensuality;
        public double TotalMensuality => BaseMensuality + InsuranceMensuality;
        public readonly double TotalInterest;
        public readonly double TotalInsuranceInterest;

        public readonly double CurrentCapitalPaid;

        public LoanSummary(int currentMonth, double baseMensuality, double insuranceMensuality, double totalInterest, double totalInsuranceInterest, double currentCapitalPaid)
        {
            CurrentMonth = currentMonth;
            BaseMensuality = baseMensuality;
            InsuranceMensuality = insuranceMensuality;
            TotalInterest = totalInterest;
            TotalInsuranceInterest = totalInsuranceInterest;
            CurrentCapitalPaid = currentCapitalPaid;
        }
    }
}
