using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain_Text_Generator
{
    internal class TextEndMarkovNode : INode<string>
    {
        public string State { get; init; } = "**End.**";
    }
}
