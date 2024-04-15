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
        //Loop for user to enter ingredient information
        for (int i = 0; i < IngNum; i++)
        {
            Write("Enter the Name of ingredient number " + (i + 1) + ":");
            string Name = ReadLine();

            Write("Enter the Quantity of '"+  Name +"'" + ":");
            float Quantity = float.Parse(ReadLine());

            Write("Enter the Unit of Measure for '"+  Name +"'" + ":");
            string Measure = ReadLine();
            //Ingredients being stored into an array
            arrIngredients[i] = new Ingredient(Name, Quantity, Measure);
        }
        Write("How many steps are in the " + RecName + " recipe?");
        
        //storing of number of steps into an array
        int NumSteps = int.Parse(ReadLine());
        string[] arrSteps = new string[NumSteps];
        
        //Loop for user to enter description of each needed step
        for (int i = 0; i < NumSteps; i++)
        {
            Write("Enter the Description of step number " + (i + 1) + ":");
            arrSteps[i] = ReadLine();
        }

        //Output of different ingredients and steps
        RecOutput(RecName, arrSteps);
        
        WriteLine("Would you like to change the scale of the recipe?:\tY/N");
        Response = char.ToLower(char.Parse(ReadLine())); //Troelsen and Japikse (2024: page 76 num)
        //Changing of scale factor
        if (Response == 'y')
        {
            //user enters char value of either "a" + "b" + "c", corresponds to scale factors
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
            Clear();
        }
    
        WriteLine("Would you like to reset the scale of the recipe?:\tY/N");
        Response = char.ToLower(char.Parse(ReadLine()));
        if (Response == 'y')
        {
            for (int i = 0; i < arrIngredients.Length; i++)
            {
                arrIngredients[i].ResetScaleFactor();
            }
            RecOutput(RecName, arrSteps);
            Clear();
        }
        else if (Response == 'n')
        {
           
            Clear();
        }
 
    }
    /// <summary>
    /// Clear method used to check if user wants to clear printed recipe
    /// </summary>
    public static void Clear()
    {
        WriteLine("Would you like to clear this recipe?:\t" + RecName + "\tY/N");
        Response = char.ToLower(char.Parse(ReadLine()));
        if (Response == 'y')
        {
            //restarts the program
            Main();
        }
        else
        {
            EndOfProgram();
        }
    }
    /// <summary>
    /// EndOfProgram method used to terminate program 
    /// </summary>
    public static void EndOfProgram()
    {
        WriteLine("Enter any key to terminate appliaction");
        ReadKey();
    }
    /// <summary>
    /// RecOutput is a method used to display the full recipe that includes ingredients and steps as well as if the scale factor has been affected
    /// </summary>
    /// <param name="RecName"></param>
    /// <param name="Steps"></param>
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
#region Reference List
/*Troelsen, A.and Japikse, P. 2024. Pro C# 9 with .NET 5.
         New York: Apress.*/
#endregion
//=========================================================== EndOfProgram ===========================================================//
