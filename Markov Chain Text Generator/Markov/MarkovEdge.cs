using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Chain_Text_Generator
{
    public class MarkovEdge <TNode> 
        where TNode : MarkovNode<string>
    {
        public int Weight { get; set; }
        public Probability Probably { get; set; }
        public TNode Start { get; init; }
        public TNode End { get; init; }
        public override string ToString()
        {
            return $"|{Start.State}|-->--{{p={Probably}, w={Weight}}}---->|{End.State}|";
        }

        public MarkovEdge(TNode start, TNode end, int weight=1)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
            Weight = weight;
        }


    }
}
