using System.Text.Json;
using Markov_Chain_Text_Generator;


var fish = new TextMarkovNode("fish");
var one = new TextMarkovNode("one");
var two = new TextMarkovNode("two");
var three = new TextMarkovNode("three");


fish.AddTransition(one);
fish.AddTransition(two);
fish.AddTransition(three);
fish.AddTransition(fish);


Console.WriteLine(fish);

var dict = new Dictionary<string, int>
{
	["one"]= 0,
	["two"]= 0,
	["three"]= 0,
	["fish"]= 0,
};

for (int i = 0; i < 1000; i++)
{
	dict[fish.NextNode.State]++;
}

Console.WriteLine(
		JsonSerializer.Serialize<Dictionary<string, int>>(
			dict, 
			new JsonSerializerOptions { WriteIndented = true }
		)
	);

