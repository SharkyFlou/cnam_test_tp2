using LoanLibrary.InsuranceInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.InsuranceInterest.LoadModifiers
{
    public interface IInterestModifiersLoader
    {
        public List<InterestInsuranceModifier> GetAllInterestInsuranceModifier();
    }
}
