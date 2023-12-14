// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int a = 12;
        Console.WriteLine("number is " + a);
        string s = "It is a string";
        Console.WriteLine(s);
        Console.WriteLine($"String is: {s}");
        var v = 24;
        Console.WriteLine($"It is var value = {v}");
        dynamic height = 13.2;
        
    }
}