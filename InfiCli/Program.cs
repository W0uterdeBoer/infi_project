using System;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {   
        var lines = File.ReadAllLines("Cameras-defb.csv");
        List<String> result = Search.FindMatches(lines, args[0]);
        result.ForEach(line => Console.WriteLine(line));  
        if (result.Count == 0){
            Console.WriteLine("no results");
        }    
    }
}