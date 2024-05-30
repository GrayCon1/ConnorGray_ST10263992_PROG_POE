using static System.Console;
public static class Util
{/// <summary>
/// Simple Addition of a header change allowing for the input of 2 different colours as well as text.
/// </summary>
/// <param name="headerText"></param>
/// <param name="colour1"></param>
/// <param name="colour2"></param>
    public static void Header(string headerText, ConsoleColor colour1, ConsoleColor colour2)
    {
        ForegroundColor = colour1;
        WriteLine("\t" + headerText);
        ForegroundColor = colour2;
    }
    

}