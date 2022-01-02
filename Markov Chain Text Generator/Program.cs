using System.Text.Json;
using Markov_Chain_Text_Generator;



var fish = new TextMarkovNode("fish");
var one = new TextMarkovNode("one");
var two = new TextMarkovNode("two");
var three = new TextMarkovNode("three");


fish.AddTransition(one);
fish.AddTransition(one)
    .AddTransition(two);

fish.AddTransition(two)
    .AddTransition(one)
    .AddTransition(fish);

fish.AddTransition(fish);


Console.WriteLine(fish);
Console.WriteLine(one);
Console.WriteLine(two);

Console.WriteLine(fish.NextNode.State);
Console.WriteLine(fish.NextNode.State);
Console.WriteLine(fish.NextNode.State);
Console.WriteLine(fish.NextNode.State);



