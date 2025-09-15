namespace  Hemy.Cli;

using System.CommandLine;
using System.CommandLine.Invocation;

public static class Program
{

    public static int Main(string[] args)
    {
        var rootCommand = new RootCommand
        {
            new Option<int>("--number", "An integer option"),
            new Option<bool>("--flag", "A boolean option"),
            // new Argument<string>("input", "A required input argument")
        };

        // rootCommand. = CommandHandler.Create<int, bool, string>((number, flag, input) =>
        // {
        //     // Your application logic goes here
        //     Console.WriteLine($"Number: {number}");
        //     Console.WriteLine($"Flag: {flag}");
        //     Console.WriteLine($"Input: {input}");
        // });

        // return rootCommand.Invoke(args);
        return 0;
    }    

}

/*
dotnet add package System.CommandLine --version 2.0.0-rc.1.25451.107
USAGE :
dotnet run -- --number 42 --flag true "Hello, CLI!"
*/