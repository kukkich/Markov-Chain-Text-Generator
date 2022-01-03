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
			while (!streamReader.EndOfStream)
				foreach (string word in streamReader
						?.ReadLine()
						?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? throw new NullReferenceException()
					)
					Push(word);
		}

		public TextGenerator (string text)
		{
			throw new NotImplementedException ();
		}

		private void Push(string word)
		{
			throw new NotImplementedException();
		}
		private TextStartMarkovNode _start;
		private TextMarkovNode _lastReadNode;
	}
}
