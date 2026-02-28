using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanLibrary.Interests;

namespace LoanLibrary.Interfaces
{
    public interface LoanUI
    {
        public List<InterestModifier> AskUserModifiers();
        public Loan AskUserLoan();
    }
}
