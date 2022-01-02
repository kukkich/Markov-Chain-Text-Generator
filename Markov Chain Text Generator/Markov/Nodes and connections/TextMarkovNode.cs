using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Markov_Chain_Text_Generator
{
	public class TextMarkovNode : INode<string>
	{
		public TextMarkovNode AddTransition(TextMarkovNode node, int usages=1)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));
			if (usages < 0) throw new ArgumentOutOfRangeException(nameof(usages));

			int childIndex;
			TextMarkovNode result = null;

			for (childIndex = 0; childIndex < _edges.Count; childIndex++)
				if (_edges[childIndex].End.State == node.State)
					break;

			if (childIndex < _edges.Count)
			{
				_edges[childIndex].Weight += usages;
				result = _edges[childIndex].End;
			}
			else if (childIndex == _edges.Count)
			{
				result = node;
				_edges.Add(new MarkovEdge<TextMarkovNode>(this, result, usages));
			}
			else
			{
				throw new Exception("UnexpectedError in " + nameof(TextMarkovNode) + "." + nameof(AddTransition));
			}

			_totalUsages += usages;
			RecalculateProbabilities();

			return result;
		}
		public TextMarkovNode AddTransition(string state, int usages=1)
		{
			if (state == null) throw new ArgumentNullException(nameof(state));

			return AddTransition(new TextMarkovNode(state), usages);
		}

		[JsonIgnore]
		public TextMarkovNode NextNode
		{
			get 
			{ 
				double p = _randomDevice.NextDouble();

				foreach (var edge in _edges)
					if (p < edge.Probably)
						return edge.End;
					else
						p -= edge.Probably;

				throw new Exception("UnexpectedError in " + nameof(TextMarkovNode) + "." + nameof(NextNode));
			}
		}

        public string State { get; init; }

        public override string ToString()
		{
			var edgesLog = new StringBuilder();
			if (_edges.Count > 0)
			{
				edgesLog.Append("[\n");
				// !!!TODO make serialization
				foreach (var edge in _edges)
				{
					edgesLog.AppendLine(_serializerTabs + edge.ToString() + ",");
				}
				edgesLog.AppendLine("]");
			}

			return edgesLog + JsonSerializer.Serialize<TextMarkovNode>(this, _serializerOption);
		}

		public TextMarkovNode(string state)
		{
            State = state ?? throw new ArgumentNullException(nameof(state));
		}

		// With long calculation make it public
		// and remove it from the end of AddTransition method
		// so that it can be called only 1 time 
		private void RecalculateProbabilities()
		{
			foreach (var edge in _edges)
			{
				edge.Probably = new Probability((double)edge.Weight / _totalUsages);
			}
		}

		private readonly List<MarkovEdge<TextMarkovNode>> _edges = new();

		static private readonly Random _randomDevice = new Random();
		static private readonly JsonSerializerOptions _serializerOption = new JsonSerializerOptions { WriteIndented = true };
		static private readonly string _serializerTabs = "  ";
		private int _totalUsages;

	}
}
