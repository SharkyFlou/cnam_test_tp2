using System;
using System.Collections.Generic;
using System.IO;

namespace LoanLibrary.Interests.LoadModifiers
{
    public class FileInterestModifiersLoader : GetInterestModifiers
    {
        private readonly string _filePath;

        public FileInterestModifiersLoader(string filePath)
        {
            _filePath = filePath;
        }

        public List<InterestModifier> GetAllInterestModifier()
        {
            var modifiers = new List<InterestModifier>();

            foreach (string line in File.ReadLines(_filePath))
            {
                string trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                string[] parts = trimmed.Split(',');
                if (parts.Length != 2)
                    throw new FormatException($"Invalid line format: '{trimmed}'. Expected 'name,rate'.");

                string name = parts[0].Trim();
                if (!float.TryParse(parts[1].Trim(), System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out float rate))
                    throw new FormatException($"Invalid rate value '{parts[1].Trim()}' on line: '{trimmed}'.");

                modifiers.Add(new InterestModifier(name, rate));
            }

            return modifiers;
        }
    }
}
