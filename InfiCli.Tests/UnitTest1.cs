using InfiCli;
using System.Text.RegularExpressions;
namespace InfiCli.test;

public class SearchTests
{   
    // This csvLocation is bad, right now I do not have time to fix this.
    private const string csvLocation = "../../../../InfiCli/Cameras-defb.csv";

    [Fact]
    public void Search_Finds_Lines()
    {
        string[] input = new string[] {"TestWaarde", "-123 test"};
        List<string> result = Search.FindMatches(input, "test");
        Assert.Equal(1, result.Count);
    }

    [Fact]
    public void FindMatches_Is_Case_Insensitive()
    {
        string[] input = new string[] {"TestWaarde","-123 TEST"};
        List<string> result = Search.FindMatches(input, "test");
        Assert.Equal(1 , result.Count);
    }

      [Fact]
    public void FindMatches_Formats_With_Numbers_First()
    {   
        var input = File.ReadAllLines(csvLocation);
        List<string> foundMatches = Search.FindMatches(input, "Neude");               
        foundMatches.ForEach(line => Assert.Matches("[0-9]{3}", line.Substring(0,3)));
    }
}