// See https://aka.ms/new-console-template for more information

using CommandLine;
using DotnetHomeChallenge.CommandLines;

Console.WriteLine($"{DateTime.Now} Starting process...");

var arguments = Environment.GetCommandLineArgs();
Parser.Default.ParseArguments<SearchCommand>(arguments)
    .WithParsed(command => command.Execute());

Console.WriteLine($"{DateTime.Now} ... ending process.");