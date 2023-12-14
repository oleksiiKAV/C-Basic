// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

internal class Program
{
    public void printData(dynamic value ) {
        Console.WriteLine($"This value = '{value}' is printed by class method");
    }
    private static void Main(string[] args)
    {
        Program obj = new Program();

        Console.WriteLine("Hello, World!");
        int a = 12;
        Console.WriteLine("number is " + a);
        string s = "It is a string";
        Console.WriteLine(s);
        Console.WriteLine($"String is: {s}");
        var v = 24;
        Console.WriteLine($"It is var value = {v}");
        dynamic height = 13.2;
        Console.WriteLine($"It is dynamic value = {height}");
        height = "a new height";
        Console.WriteLine($"It is dynamic value = {height}");
        obj.printData(height);
        // var - We don't know data type - type will be freeze
        // dynamic - We don't know data type - type can be changed

    }
}