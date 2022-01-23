using System.Text.Json;
using Markov_Chain_Text_Generator;
using Markov_Chain_Text_Generator.Markov;

namespace Markov_Chain_Text_Generator
{
    class Programm
    {
        public static void Main()
        {
            using (StreamReader streamReader = new StreamReader("test.txt"))
            {
                TextGenerator generator = new(streamReader);
                Console.WriteLine(generator.Generate(40));
            }
        }
    }
}






