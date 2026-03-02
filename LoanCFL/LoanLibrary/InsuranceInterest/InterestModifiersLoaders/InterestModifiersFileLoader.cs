using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.InsuranceInterest.InterstModifiersFileLoader
{
    public class InterstModifiersFileLoader : IInterestModifiersLoader
    {
        public string JsonPath;
        public List<InterestInsuranceModifier> GetAllInterestInsuranceModifier()
        {
            List<InterestInsuranceModifier> modifiers = new List<InterestInsuranceModifier>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(JsonPath);
                foreach (string line in lines)
                {
                    InterestInsuranceModifier modifier = GetInterestInsuranceModifierFromFile(line);
                    modifiers.Add(modifier);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading interest insurance modifiers from file: {ex.Message}");
            }
            return modifiers;

        }

        //Format is like "id,ModifierName,ModifierValue,ModifierType"
        private static InterestInsuranceModifier GetInterestInsuranceModifierFromFile(string lineInput)
        {
            string[] splitInput = lineInput.Split(',');
            if(splitInput.Length != 4)
            {
                throw new Exception("Invalid line format in file.");
            }

            int id = int.Parse(splitInput[0]);
            string modifierName = splitInput[1];
            float modifierValue = float.Parse(splitInput[2]);
            string modifierType = splitInput[3];
            InterestInsuranceType insuranceType;
            switch (modifierType)
            {
                case "Job":
                    insuranceType = InterestInsuranceType.Job;
                    break;
                case "Habits":
                    insuranceType = InterestInsuranceType.Habits;
                    break;
                default:
                    throw new Exception("Invalid modifier type in file.");
            }
            return new InterestInsuranceModifier(modifierName, modifierValue, insuranceType);
        } 
    }
}
