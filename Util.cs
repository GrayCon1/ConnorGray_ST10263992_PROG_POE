using static System.Console;
public static class Util
{
    public static void Header(string headerText, ConsoleColor colour1, ConsoleColor colour2)
    {
        ForegroundColor = colour1;
        WriteLine("\t" + headerText);
        ForegroundColor = colour2;
    }
    

}