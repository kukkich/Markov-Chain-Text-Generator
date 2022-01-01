using System;

namespace Markov_Chain_Text_Generator
{
	public abstract class MarkovNode<T>
	{
		public T State { get; init; }

		public MarkovNode(T state)
		{
			if (state == null) throw new ArgumentNullException(nameof(state));
			State = state;
		}

	}
}