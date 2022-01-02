using System;

namespace Markov_Chain_Text_Generator
{
	public interface INode<T>
	{
		public T State { get; init; }
	}
}