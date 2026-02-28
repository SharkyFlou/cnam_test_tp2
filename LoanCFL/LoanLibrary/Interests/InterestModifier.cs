using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.Interests
{
    public class InterestModifier
    {
        public readonly string _name;
        public readonly float _rate;

        public InterestModifier(string name, float rate)
        {
            _name = name;
            _rate = rate;
        }
    }
}
