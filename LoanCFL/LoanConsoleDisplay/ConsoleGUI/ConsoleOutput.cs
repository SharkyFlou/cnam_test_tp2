using LoanLibrary.InsuranceInterest;
using LoanLibrary.Interests;
using LoanLibrary.LoanData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDisplay.ConsoleGUI
{
    public class ConsoleOutput : IOutput
    {
        public void AskCurrentYear()
        {
            Console.WriteLine("Please enter the current year:");
        }

        public void AskDurationInYears()
        {
            Console.WriteLine("Please enter the duration of the loan in years:");
        }

        public void AskForCapital()
        {
            Console.WriteLine("Please enter the capital you want to borrow:");
        }

        public void AskForJob(List<InterestInsuranceModifier> availableJobs)
        {
            Console.WriteLine("Please select your job from the following list:");
            for (int i = 0; i < availableJobs.Count; i++)
            {
                Console.WriteLine($"{i}: {availableJobs[i]._name}");
            }
        }

        public void AskHabit(InterestInsuranceModifier habit)
        {
            Console.WriteLine($"Do you have the habit: {habit._name}? (y/n)");
        }

        public void AskInterestQuality(List<InterestType> interestTypes)
        {
            Console.WriteLine("Please select the quality of your interest from the following list:");
            for (int i = 0; i < interestTypes.Count; i++)
            {
                Console.WriteLine($"{i}: {interestTypes[i].ToString()}");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayResult(LoanSummary summary)
        {
            Console.WriteLine($"Months Elapsed\t\t: {summary.CurrentMonth}");
            Console.WriteLine($"Base Mensuality\t\t: {summary.BaseMensuality:F2}");
            Console.WriteLine($"Insurance Mensuality\t: {summary.InsuranceMensuality:F2}");
            Console.WriteLine($"Total Mensuality\t: {summary.TotalMensuality:F2}");
            Console.WriteLine($"Total Interest\t\t: {summary.TotalInterest:F2}");
            Console.WriteLine($"Total Insurance\t\t: {summary.TotalInsuranceInterest:F2}");
            Console.WriteLine($"Current Capital Paid\t: {summary.CurrentCapitalPaid:F2}");
        }
    }
}
