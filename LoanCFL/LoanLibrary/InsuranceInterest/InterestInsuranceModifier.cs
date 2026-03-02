using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLibrary.InsuranceInterest
{
    public class InterestInsuranceModifier
    {
        public readonly int _id;
        public readonly string _name;
        public readonly float _rate;
        public readonly InterestInsuranceType _interestInsuranceType;

        public InterestInsuranceModifier(string name, float rate, InterestInsuranceType interestInsuranceType, int id)
        {
            _name = name;
            _rate = rate;
            _interestInsuranceType = interestInsuranceType;
            _id = id;
        }
    }
}
