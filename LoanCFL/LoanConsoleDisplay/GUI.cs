using LoanDisplay;
using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanConsoleDisplay
{
    public class GUI
    {
        IInput _input;
        IOutput _output;

        public GUI(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        public InterestInsuranceModifier GetJob(List<InterestInsuranceModifier> availableJobs)
        {
            _output.AskForJob(availableJobs);
            return _input.GetJob();
        }

        public List<InterestInsuranceModifier> GetHabits(List<InterestInsuranceModifier> availableHabits)
        {
            _output.AskHabits(availableHabits);
            return _input.GetHabits();
        }

        public InterestType GetInterestQuality(List<InterestType> interestTypes)
        {
            _output.AskInterestQuality(interestTypes);
            return _input.GetInterestQuality();
        }


    }
}
