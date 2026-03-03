using LoanDisplay.ConsoleGUI;
using LoanLibrary.InsuranceInterest;
using LoanLibrary.InsuranceInterest.InterstModifiersFileLoader;
using LoanLibrary.Interests;
using LoanLibrary.LoanData;
using LoanLibrary.Rules;

namespace LoanApp
{
    public class LoanApp
    {
        public static string InsuranceModifiersFile = "InsuranceModifiers.txt";
        public static void Main(string[] args)
        {
            //create GUI
            ConsoleInput input = new ConsoleInput();
            ConsoleOutput output = new ConsoleOutput();
            LoanConsoleDisplay.GUI gui = new LoanConsoleDisplay.GUI(input, output);

            //get insurances modifiers
            InterstModifiersFileLoader fileLoader = new InterstModifiersFileLoader();
            fileLoader.SetFilePath(InsuranceModifiersFile);
            List<InterestInsuranceModifier> insuranceModifiers = fileLoader.GetAllInterestInsuranceModifier();
            //Habits and Jobs are separated by type, so we can easily filter them
            List<InterestInsuranceModifier> availableJobs = insuranceModifiers.Where(modifier => modifier._interestInsuranceType == InterestInsuranceType.Job).ToList();
            List<InterestInsuranceModifier> availableHabits = insuranceModifiers.Where(modifier => modifier._interestInsuranceType == InterestInsuranceType.Habits).ToList();
            Loan loan = GetLoan(gui, availableJobs, availableHabits);

            //getting current year
            int currentYear = GetCurrentYear(gui, loan.DurationMonths/12);

            //calculate summary
            var summary = LoanLibrary.LoanCalculator.CalculateLoanSummary(loan, currentYear * 12);

            //display result, 
            output.DisplayResult(summary);
        }

        private static int GetCurrentYear(LoanConsoleDisplay.GUI gui, int maxYear)
        {
            int currentYear = 0;
            while (currentYear <= 0)
            {
                try
                {
                    currentYear = gui.GetCurrentYear();
                    if (currentYear > maxYear)
                    {
                        currentYear = 0;
                        throw new Exception($"Current year cannot be greater than loan duration ({maxYear} years).");
                    }
                }
                catch (Exception ex)
                {
                    gui.DisplayMessage(ex.Message);
                }
            }

            return currentYear;
        }

        public static Loan GetLoan(LoanConsoleDisplay.GUI gui, List<InterestInsuranceModifier> availableJobs, List<InterestInsuranceModifier> availableHabits)
        {
            //while loops to get valid loan info

            //getting capital
            int capital;
            while (true)
            {
                try
                {
                    capital = gui.GetCapital();
                    if (capital < LoanRules.CAPITAL_MIN)
                    {
                        throw new Exception($"Capital must be at least {LoanRules.CAPITAL_MIN}.");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    gui.DisplayMessage(ex.Message);
                }
            }

            //getting yearduration
            int durationInYears = 0;
            while (durationInYears <= 0)
            {
                try
                {
                    durationInYears = gui.GetDurationInYears();
                    if (durationInYears < LoanRules.DURATION_MIN)
                    {
                        durationInYears = 0; 
                        throw new Exception($"Duration must be at least {LoanRules.DURATION_MIN} years.");
                    }
                    if (durationInYears > LoanRules.DURATION_MAX)
                    {
                        durationInYears = 0; 
                        throw new Exception($"Duration cannot be greater than {LoanRules.DURATION_MAX} years.");
                    }
                }
                catch (Exception ex)
                {
                    gui.DisplayMessage(ex.Message);
                }
            }


            //getting job
            InterestInsuranceModifier job = null;
            while (job == null)
            {
                try
                {
                    job = gui.GetJob(availableJobs);
                }
                catch (Exception ex)
                {
                    gui.DisplayMessage(ex.Message);
                }
            }

            //getting habits
            List<InterestInsuranceModifier> habits = new List<InterestInsuranceModifier>();
            try
            {
                habits = gui.GetHabits(availableHabits);
            }
            catch (Exception ex)
            {
                gui.DisplayMessage(ex.Message);
            }

            //getting rate quality
            InterestType interestType;
            while (true)
            {
                try
                {
                    interestType = gui.GetInterestQuality(InterestTypeList.AllType);
                    break;
                }
                catch (Exception ex)
                {
                    gui.DisplayMessage(ex.Message);
                }
            }

            //create insuranceInterst
            //create insuranceModifierList
            List<InterestInsuranceModifier> insuranceModifierList = new List<InterestInsuranceModifier>();
            if(job != null)
                insuranceModifierList.Add(job);
            insuranceModifierList.AddRange(habits);
            InsuranceInterest insuranceInterest = new InsuranceInterest(insuranceModifierList);

            //create loan
            Loan loan = new Loan(
                capital,
                durationInYears * 12,
                insuranceInterest,
                interestType
                );
            return loan;
        }
    }
}
