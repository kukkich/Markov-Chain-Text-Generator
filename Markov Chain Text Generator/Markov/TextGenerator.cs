using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Markov_Chain_Text_Generator.Markov
{
	internal class TextGenerator
	{
		public TextGenerator (StreamReader streamReader)
		{
			Init();
			while (!streamReader.EndOfStream)
				foreach (string word in streamReader
						?.ReadLine()
						?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
						?? throw new NullReferenceException()
					)
					Push(word);
			FinishInit();
		}
		public TextGenerator (string text)
		{
			Init();
			foreach (string word in text
						?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
						?? throw new ArgumentNullException()
					)
				Push(word);
			FinishInit();
		}
		public string Generate(int maxStringLength = 50)
		{
			StringBuilder result = new StringBuilder();
			int currentStringLength = 0;

			for (TextMarkovNode readableNode = _start;
				readableNode != _end; 
				readableNode = readableNode.NextNode
				)
			{
				currentStringLength += readableNode.State.Length;
				if (currentStringLength > maxStringLength)
				{
					result.Append('\n');
					// word length + whitespace length
					currentStringLength = readableNode.State.Length + 1;
				}
				result.Append(readableNode.State);
				result.Append(' ');
			}
			result.Append(_end.State);
			return result.ToString();
		}

		private void Push(string word)
		{
			if (word == null) throw new ArgumentNullException(nameof(word));
			
			TextMarkovNode? addableNode;
			
			if (_nodes.TryGetValue(word, out addableNode))
			{
				_currentNode = _currentNode.AddTransition(addableNode);
			}
			else
			{
				_currentNode = _currentNode.AddTransition(word);
				_nodes.Add(word, _currentNode);
			}
		}
		private void Init()
		{
			_start = new TextMarkovNode("**Start**");
			_currentNode = _start;
			_end = new TextMarkovNode("**End**");
			_nodes = new();
		}
		private void FinishInit()
		{
			_currentNode.AddTransition(_end);
		}

		private Dictionary<string, TextMarkovNode> _nodes;
		private TextMarkovNode _start;
		private TextMarkovNode _end;
		private TextMarkovNode _currentNode;
	}
}
