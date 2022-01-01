using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain_Text_Generator
{
    public struct Probability
    {
        public readonly double Value;

        public static bool operator ==(Probability first, Probability second)
        {
            return first.Value == second.Value;
        }
        public static bool operator !=(Probability first, Probability second)
        {
            return first.Value != second.Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }

        public Probability(double value)
        {
            if (value < 0 || value > 1) 
                throw new ArgumentOutOfRangeException(nameof(value)); 
            Value = value;
        }

    }
}
