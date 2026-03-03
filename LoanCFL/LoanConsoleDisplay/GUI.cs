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
            return _input.GetJob(availableJobs);
        }

        public List<InterestInsuranceModifier> GetHabits(List<InterestInsuranceModifier> availableHabits)
        {
            List<InterestInsuranceModifier> habits = new List<InterestInsuranceModifier>();
            foreach (InterestInsuranceModifier habit in availableHabits)
            {
                _output.AskHabit(habit);
                if (_input.HasHabit())
                {
                    habits.Add(habit);
                }
            }
            return habits;
        }

        public InterestType GetInterestQuality(List<InterestType> interestTypes)
        {
            _output.AskInterestQuality(interestTypes);
            return _input.GetInterestQuality(interestTypes);
        }

        public int GetDurationInYears()
        {
            _output.AskDurationInYears();
            return _input.GetDurationInYears();
        }

        public int GetCurrentYear()
        {
            _output.AskCurrentYear();
            return _input.GetCurrentYear();
        }
    }
}
