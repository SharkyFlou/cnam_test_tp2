using LoanDisplay;
using LoanLibrary.InsuranceInterest;
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

        public InterestInsuranceModifier AskForJob(List<InterestInsuranceModifier> availableJobs)
        {

        }
    }
}
