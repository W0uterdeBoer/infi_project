using System;
using System.Text.RegularExpressions;

public class Search
{
    public static List<string> FindMatches(string[] lines, string search_term){
        string[][] csv = lines.Skip(1).Select(line => line.Split(';')).ToArray();

        var matchingLines = from cameraData in csv
            where LineMatches( cameraData[0], search_term) 
            select FormatLine(cameraData);
             
        return matchingLines.ToList();
    }

    private static bool LineMatches( string cameraName, string search_term)
    {   
        return Regex.Match(cameraName, search_term, RegexOptions.IgnoreCase).Success;     
    }

    private static string FormatLine( string[] cameraData){
       var numberMatch = Regex.Match(cameraData[0], "-[0-9]{3}");
       
        if(!numberMatch.Success){
            throw new NoCameraNumberException();
        }

        string cameraNumber = numberMatch.Value.Substring(1, 3);
        cameraData = cameraData.Select(str => $" {str} ").ToArray();
        return String.Join('|',cameraData.Prepend(cameraNumber + ' '));
    }
}