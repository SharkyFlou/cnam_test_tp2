using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.Interests.LoadModifiers
{
    public interface GetInterestModifiers
    {
        public List<InterestModifier> GetAllInterestModifier();
    }
}
