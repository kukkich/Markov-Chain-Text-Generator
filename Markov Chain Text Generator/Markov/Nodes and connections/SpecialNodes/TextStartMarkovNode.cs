using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain_Text_Generator
{
    internal class TextStartMarkovNode : INode<string>
    {
        public string State { get; init; } = "**Start**";
        public INode<string> NextNode { get; set; }
        public TextStartMarkovNode(INode<string> child)
        {
            NextNode = child;
        }
    }
}
