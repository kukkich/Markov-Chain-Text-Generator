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
		private static readonly Regex _extraSpacesRegex = new Regex(@"\s+", RegexOptions.Compiled);
		private static readonly string _extraSpacesReplaceTarget = " ";

		private void Push(string word)
		{
			throw new NotImplementedException();
		}

		private string RemoveExtraSpaces (string str)
		{
			return _extraSpacesRegex.Replace(str, _extraSpacesReplaceTarget);
		}

		public TextGenerator (StreamReader streamReader)
		{
			throw new NotImplementedException ();
		}

		public TextGenerator (string text)
		{
			throw new NotImplementedException ();
		}

		private TextStartMarkovNode _start;
		private TextMarkovNode _lastReadNode;
	}
}
