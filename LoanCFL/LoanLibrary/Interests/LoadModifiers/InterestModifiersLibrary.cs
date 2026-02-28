using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.Interests.LoadModifiers
{
    public static class InterestModifiersLibrary
    {
        public static List<InterestModifier> GetAllInterestModifier()
        {
            return new List<InterestModifier>() {
                new("Sportif", -0.0005f),
                new("Fumeur", 0.0015f),
                new("Atteint de troubles cardiaques", 0.003f),
                new("Ingé informatique", -0.0005f),
                new("Pilote de chasse", -0.0005f),
            };
        }
    }
}
