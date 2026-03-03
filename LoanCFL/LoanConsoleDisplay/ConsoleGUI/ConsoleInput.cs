using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;

namespace LoanDisplay.ConsoleGUI
{
    public class ConsoleInput : IInput
    {
        private int GetUserPositiveInt()
        {
            //if fail, throw exception, otherwise return result
            int result;
            if (!int.TryParse(Console.ReadLine(), out result))
            {
                throw new Exception("Invalid input, expected an integer.");
            }
            if(result < 0) {
                throw new Exception("Invalid input, expected a positive integer.");
            }
            return result;
        }
        public int GetCurrentYear()
        {
            return GetUserPositiveInt();
        }

        public int GetDurationInYears()
        {
            return GetUserPositiveInt();
        }
        public int GetCapital()
        {
            return GetUserPositiveInt();
        }

        public bool HasHabit()
        {
            string input = Console.ReadLine();
            return input?.ToLower() == "y";
        }

        public InterestType GetInterestQuality(List<InterestType> interestTypes)
        {
            int type = GetUserPositiveInt();
            if (type < 0 || type >= interestTypes.Count)
            {
                throw new Exception("Invalid input, expected a number corresponding to an interest type.");
            }
            return interestTypes[type];
        }

        public InterestInsuranceModifier GetJob(List<InterestInsuranceModifier> availableJobs)
        {
            int type = GetUserPositiveInt();
            if (type < 0 || type >= availableJobs.Count)
            {
                throw new Exception("Invalid input, expected a number corresponding to a job.");
            }
            return availableJobs[type];     
        }
    }
}
