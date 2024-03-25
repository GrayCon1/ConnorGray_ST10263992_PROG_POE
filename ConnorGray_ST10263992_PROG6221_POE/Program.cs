using static System.Console;

namespace ConnorGray_ST10263992_PROG6221_POE;

public class Program
{
    private static Ingredient[] arrIngredients;
private static string RecName;
private static char Response;
    private static void Main()
    {
        Write("Enter the name for the recipe: ");
          RecName = ReadLine();
        Write("How many different ingredients are used?: ");
        int IngNum = int.Parse(ReadLine());

        arrIngredients = new Ingredient[IngNum];
        for (int i = 0; i < IngNum; i++)
        {
            Write("Enter the Name of ingredient number " + (i + 1) + ":");
            string Name = ReadLine();

            Write("Enter the Quantity of ingredient number " + (i + 1) + ":");
            float Quantity = float.Parse(ReadLine());

            Write("Enter the Unit of Measure of ingredient number " + (i + 1) + ":");
            string Measure = ReadLine();

            arrIngredients[i] = new Ingredient(Name, Quantity, Measure);
        }
        Write("How many steps are in the " + RecName + " recipe?");
        int NumSteps = int.Parse(ReadLine());

        string[] arrSteps = new string[NumSteps];
        for (int i = 0; i < NumSteps; i++)
        {
            Write("Enter the Description of step number " + (i + 1) + ":");
            arrSteps[i] = ReadLine();
        }
        RecOutput(RecName, arrSteps);
        //
        WriteLine("Would you like to change the scale of the recipe?:\tY/N");
        Response = char.ToLower(char.Parse(ReadLine()));

        if (Response == 'y')
        {
            WriteLine("Do you want it to be:\n\na) Halved\tb) Doubled\tc) Tripled\n\nplease select 'a' or 'b' or 'c'");
            char scaleFactor = char.Parse(ReadLine());
            for (int i = 0; i < arrIngredients.Length; i++)
            {
                arrIngredients[i].Quantity = arrIngredients[i].ScaleFactor(scaleFactor);
            }
            RecOutput(RecName, arrSteps);
        }
        else
        {
            EndOfProgram();
        }
        //
        WriteLine("Would you like to reset the scale of the recipe?:\tY/N");
        Response = char.ToLower(char.Parse(ReadLine()));
        if (Response == 'y')
        {
            for (int i = 0; i < arrIngredients.Length; i++)
            {
                arrIngredients[i].ResetScaleFactor();
            }
            RecOutput(RecName, arrSteps);
        }
        else if (Response == 'n')
        {
            Clear();
        }
        else
        {
            EndOfProgram();
        }
 
    }
    public static void Clear()
    {
        WriteLine("Would you like to clear this recipe?:\t" + RecName + "\tY/N");
        Response = char.ToLower(char.Parse(ReadLine()));
        if (Response == 'y')
        {
            Main();
        }
        else
        {
            EndOfProgram();
        }
    }
    public static void EndOfProgram()
    {
        WriteLine("Enter any key to terminate appliaction");
        ReadKey();
    }
    public static void RecOutput(string RecName, string[] Steps)
    {
        int length = Math.Max(arrIngredients.Length, Steps.Length);
        Ingredient[] arrOutIng = new Ingredient[length];
        string[] arrOutStep = new string[length];
        Array.Copy(arrIngredients, arrOutIng, arrIngredients.Length);
        Array.Copy(Steps, arrOutStep, Steps.Length);

        WriteLine(RecName + ":" + "\n==========================================================================" +
        "\nIngredients: (" + arrOutIng.Length
        + ")" + "\t\tSteps: (" + arrOutStep.Length + ")");

        for (int i = 0; i < length; i++)
        {

            WriteLine(i + 1 + ")" + arrOutIng[i]?.Name + "\t" +
            arrOutIng[i]?.Quantity + " " +
            arrOutIng[i]?.Measure + "\t\t\t" + (i + 1) + ")" + arrOutStep?[i]);
        }


        WriteLine("\n==========================================================================");
    }
}
