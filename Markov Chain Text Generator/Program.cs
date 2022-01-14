using System.Text.Json;
using Markov_Chain_Text_Generator;
using Markov_Chain_Text_Generator.Markov;

namespace Markov_Chain_Text_Generator
{
    class Programm
    {
        public static void Main()
        {
            // string text = "fish one fish two fish three fish one fish one fish";

            // from file
            using (StreamReader streamReader = new StreamReader("test.txt"))
            {
                //while (!streamReader.EndOfStream)
                //	foreach (string word in streamReader
                //			?.ReadLine()
                //			?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? throw new NullReferenceException()
                //		)
                TextGenerator generator = new(streamReader);
                Console.WriteLine(generator.Generate(40));
            }


        }
    }
}






