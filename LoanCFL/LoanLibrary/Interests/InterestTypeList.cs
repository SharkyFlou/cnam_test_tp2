using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.Interests
{
    public static class InterestTypeList
    {
        public static readonly List<InterestType> AllType =
        [
            InterestType.GoodRate,
            InterestType.VeryGoodRate,
            InterestType.ExcellentRate
        ];
    }
}
