using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanLibrary.Rules;

namespace LoanLibrary.Interests
{
    public class InterestTableCalculator
    {
        private static readonly Dictionary<InterestType, Dictionary<int, double>> InterestTable = new Dictionary<InterestType, Dictionary<int, double>>
        {
            [InterestType.GoodRate] = new Dictionary<int, double> { [7] = 0.62, [10] = 0.67, [15] = 0.85, [20] = 1.04, [25] = 1.27 },
            [InterestType.VeryGoodRate] = new Dictionary<int, double> { [7] = 0.43, [10] = 0.55, [15] = 0.73, [20] = 0.91, [25] = 1.15 },
            [InterestType.ExcellentRate] = new Dictionary<int, double> { [7] = 0.35, [10] = 0.45, [15] = 0.58, [20] = 0.73, [25] = 0.89 },
        };

        private static int RoundYears(int years)
        {
            if (years < LoanRules.DURATION_MIN)
                throw new ArgumentException("Years must be at least 9 years to use the interest table.");
            if (years > LoanRules.DURATION_MAX)
                throw new ArgumentException("Years must be at most 25 years to use the interest table.");

            if (years <= 9) return 7;
            if (years <= 10) return 10;
            if (years <= 15) return 15;
            if (years <= 20) return 20;
            return 25; // For any years above 20, we use the 25-year rate
        }
        
        public static double GetInterestRate(InterestType interestType, int months)
        {
            int years = (int)Math.Ceiling(months / 12.0);

            int roundedYears = RoundYears(years);
            return InterestTable[interestType][roundedYears];
        }
    }
}
