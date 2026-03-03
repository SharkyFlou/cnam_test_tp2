using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.InsuranceInterest.InterstModifiersFileLoader
{
    public class InterstModifiersFileLoader : IInterestModifiersLoader
    {
        private string _filePath;

        public void SetFilePath(string filePath)
            { _filePath = filePath; }
        public List<InterestInsuranceModifier> GetAllInterestInsuranceModifier()
        {
            
            List<InterestInsuranceModifier> modifiers = new List<InterestInsuranceModifier>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(_filePath);
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

        //Format is like "ModifierName;ModifierValue;ModifierType"
        private static InterestInsuranceModifier GetInterestInsuranceModifierFromFile(string lineInput)
        {
            string[] splitInput = lineInput.Split(';');
            if(splitInput.Length != 3)
            {
                throw new Exception("Invalid line format in file.");
            }

            string modifierName = splitInput[0];
            float modifierValue = float.Parse(splitInput[1]);
            string modifierType = splitInput[2];
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
